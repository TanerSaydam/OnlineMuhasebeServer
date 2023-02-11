using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyServices;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport;

public sealed class GetAllReportQueryHandler : IQueryHandler<GetAllReportQuery, GetAllReportQueryResponse>
{
    private readonly IReportService _reportService;

    public GetAllReportQueryHandler(IReportService reportService)
    {
        _reportService = reportService;
    }

    public async Task<GetAllReportQueryResponse> Handle(GetAllReportQuery request, CancellationToken cancellationToken)
    {
        return new(await _reportService.GetAllReportsByCompanyId(request.CompanyId));
    }
}
