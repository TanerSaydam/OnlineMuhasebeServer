using Azure.Core;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Dtos;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.ReportRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.Services.CompanyServices;

public class ReportService : IReportService
{
    private CompanyDbContext _context;
    private readonly IContextService _contextService;
    private readonly IReportCommandRepository _commandRepository;
    private readonly IReportQueryRepository _queryRepository;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IRabbitMQService _rabbitmqService;
    public ReportService(IContextService contextService, IReportCommandRepository commandRepository, IReportQueryRepository queryRepository, ICompanyDbUnitOfWork unitOfWork, IRabbitMQService rabbitmqService)
    {
        _contextService = contextService;
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
        _rabbitmqService = rabbitmqService;
    }

    public async Task<IList<Report>> GetAllReportsByCompanyId(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return await _queryRepository.GetAll(false).OrderByDescending(p => p.CreatedDate).ToListAsync();
    }

    public async Task Request(RequestReportCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        
        Report report = new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Status = false
        };

        await _commandRepository.AddAsync(report, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        SendQueue(report, request.CompanyId);
    }

    public void SendQueue(Report report, string companyId)
    {
        ReportDto reportDto = new()
        {
            Id = report.Id,
            Name = report.Name,
            CompanyId = companyId
        };

        _rabbitmqService.SendQueue(reportDto);
    }
}
