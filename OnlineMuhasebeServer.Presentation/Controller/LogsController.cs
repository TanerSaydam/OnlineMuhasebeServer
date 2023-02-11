using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.LogFeatures.Queires.GetLogsByTableName;
using OnlineMuhasebeServer.Presentation.Abstraction; 

namespace OnlineMuhasebeServer.Presentation.Controller;

[Authorize(AuthenticationSchemes ="Bearer")]
public class LogsController : ApiController
{
    public LogsController(IMediator mediator) : base(mediator) {}

    [HttpPost("[action]")]
    public async Task<IActionResult> GetLogsByTableName(GetLogsByTableNameQuery request)
    {
        GetLogsByTableNameQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
