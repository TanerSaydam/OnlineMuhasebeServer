using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport;
using OnlineMuhasebeServer.Presentation.Abstraction; 

namespace OnlineMuhasebeServer.Presentation.Controller;

public class ReportsController : ApiController
{
    public ReportsController(IMediator mediator) : base(mediator) {}

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllReportQuery request)
    {
        GetAllReportQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RequestReport(RequestReportCommand request, CancellationToken cancellationToken)
    {
        RequestReportCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
