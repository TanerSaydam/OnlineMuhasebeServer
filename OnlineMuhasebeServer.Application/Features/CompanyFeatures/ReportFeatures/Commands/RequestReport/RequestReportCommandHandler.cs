using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;

public sealed class RequestReportCommandHandler : ICommandHandler<RequestReportCommand, RequestReportCommandResponse>
{
    private readonly IReportService _reportService;

    public RequestReportCommandHandler(IReportService reportService)
    {
        _reportService = reportService;
    }

    public async Task<RequestReportCommandResponse> Handle(RequestReportCommand request, CancellationToken cancellationToken)
    {
        await _reportService.Request(request, cancellationToken);
        return new();
    }
}
