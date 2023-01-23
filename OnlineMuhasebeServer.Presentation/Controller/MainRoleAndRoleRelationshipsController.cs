using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRoleRL;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.RemoveByIdMainRoleAndRoleRL;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Queries;
using OnlineMuhasebeServer.Presentation.Abstraction; 

namespace OnlineMuhasebeServer.Presentation.Controller;

public class MainRoleAndRoleRelationshipsController : ApiController
{
    public MainRoleAndRoleRelationshipsController(IMediator mediator) : base(mediator) {}

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateMainRoleAndRoleRLCommand request, CancellationToken cancellationToken)
    {
        CreateMainRoleAndRoleRLCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveById(RemoveByIdMainRoleAndRoleRLCommand request)
    {
        RemoveByIdMainRoleAndRoleRLCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll()
    {
        GetAllMainRoleAndRoleRLQuery request = new();
        GetAllMainRoleAndRoleRLQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

}
