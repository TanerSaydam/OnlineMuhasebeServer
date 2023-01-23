using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRL;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.RemoveByIdMainRoleAndUserRL;
using OnlineMuhasebeServer.Presentation.Abstraction; 

namespace OnlineMuhasebeServer.Presentation.Controller;

public class MainRoleAndUserRelationshipsController : ApiController
{
    public MainRoleAndUserRelationshipsController(IMediator mediator) : base(mediator) {}

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateMainRoleAndUserRLCommand request)
    {
        CreateMainRoleAndUserRLCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    } 
    
    [HttpPost("[action]")]
    public async Task<IActionResult> RevmoveById(RemoveByIdMainRoleAndUserRLCommand request)
    {
        RemoveByIdMainRoleAndUserRLCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
