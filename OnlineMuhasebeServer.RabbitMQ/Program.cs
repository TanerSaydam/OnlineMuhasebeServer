using ClosedXML.Excel;
using Newtonsoft.Json;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Dtos;
using OnlineMuhasebeServer.Persistance.Context;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace OnlineMuhasebeServer.RabbitMQ;

internal class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory();
        factory.Uri = new Uri("amqps://kterupdv:L0IAgF-B6n_QfoR5yY_dt5kj6z2LBeGC@moose.rmq.cloudamqp.com/kterupdv");

        using var connection = factory.CreateConnection();

        var channel = connection.CreateModel();

        channel.QueueDeclare("Reports", true, false, false);

        var consumer = new EventingBasicConsumer(channel);
        channel.BasicConsume("Reports", true, consumer);

        consumer.Received += Consumer_Received;

        Console.ReadLine();
    }        

    private static void Consumer_Received(object? sender, BasicDeliverEventArgs e)
    {
        string reportString = Encoding.UTF8.GetString(e.Body.ToArray());
        ReportDto reportDto = JsonConvert.DeserializeObject<ReportDto>(reportString);

        if(reportDto.Name == "Hesap Planı")
        {
            CreateUCAFExcel(reportDto);
        }
    }

    public static void CreateUCAFExcel(ReportDto reportDto)
    {
        Context.AppDbContext appDbContext = new();
        Company company = appDbContext.Set<Company>().Find(reportDto.CompanyId);

        CompanyDbContext companyDbContext = new(company);
        IList<UniformChartOfAccount> ucafs = companyDbContext.Set<UniformChartOfAccount>().OrderBy(p=> p.Code).ToList();

        string fileName = "";

        using (var workbook = new XLWorkbook())
        {
            var ws = workbook.Worksheets.Add("Hesap Planı");
            ws.Range("A1").Value = company.Name + " Hesap Planı";
            

            ws.Range("A1:C1").Merge();
            ws.Range("A1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Range("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range("A1").Style.Font.FontSize = 20;

            ws.Range("A3").Value = "Kod";
            ws.Range("B3").Value = "Tip";
            ws.Range("C3").Value = "Adı";

            int rowCount = 4;
            for (int i = 0; i < ucafs.Count(); i++)
            {
                ws.Range("A" + rowCount).Value = ucafs[i].Code;
                ws.Range("B" + rowCount).Value = ucafs[i].Type.ToString();
                ws.Range("C" + rowCount).Value = ucafs[i].Name;

                if (ucafs[i].Type.ToString() == "A")
                    ws.Range($"A{rowCount}:C{rowCount}").Style.Font.FontColor = XLColor.Red;
                else if(ucafs[i].Type.ToString() == "G")
                    ws.Range($"A{rowCount}:C{rowCount}").Style.Font.FontColor = XLColor.Blue;

                rowCount++;
            }
            
            ws.Range("A:C").Style.Font.Bold = true;
            ws.Columns("A:C").AdjustToContents();

            int lastRow = ws.LastRowUsed().RowNumber();

            ws.Range($"A3:C{lastRow}").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range($"A3:C{lastRow}").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Range($"A3:C{lastRow}").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range($"A3:C{lastRow}").Style.Border.LeftBorder = XLBorderStyleValues.Thin;            

            fileName = ($"HesapPlani.{company.Id}.{DateTime.Now}.xlsx").Replace(":",".");
            string filePath = $"C:/MyProjects/OnlineMuhasebe/OnlineMuhasebeClient/src/assets/reports/{fileName}";

            workbook.SaveAs(filePath);
        }

        Report report = companyDbContext.Set<Report>().Find(reportDto.Id);
        report.FileUrl = fileName;
        report.Status = true;
        report.UpdatedDate = DateTime.Now;

        companyDbContext.Update(report);
        companyDbContext.SaveChanges();

        Console.WriteLine("Excel başarıyla oluşturuldu!");
    }
}