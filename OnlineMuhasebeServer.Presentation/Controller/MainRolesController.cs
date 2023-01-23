using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateStaticMainRoles;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Queries.GetAllMainRole;
using OnlineMuhasebeServer.Presentation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller;

public sealed class MainRolesController : ApiController
{
    public MainRolesController(IMediator mediator) : base(mediator)
    {
    }

    //[HttpPost("[action]")]
    //public async Task<IActionResult> CreateMainRole(CreateMainRoleCommand request, CancellationToken cancellationToken)
    //{
    //    CreateMainRoleCommandResponse response = await _mediator.Send(request, cancellationToken);
    //    return Ok(response);
    //}

    //[HttpPost("[action]")]
    //public async Task<IActionResult> CreateStaticMainRoles(CreateStaticMainRolesCommand request, CancellationToken cancellationToken)
    //{
    //    CreateStaticMainRolesCommandResponse response = await _mediator.Send(request, cancellationToken);
    //    return Ok(response);
    //}

    //[HttpPost("[action]")]
    //public async Task<IActionResult> GetAllMainRole(GetAllMainRoleQuery request)
    //{
    //    GetAllMainRoleQueryResponse response = await _mediator.Send(request);
    //    return Ok(response);
    //}


}
