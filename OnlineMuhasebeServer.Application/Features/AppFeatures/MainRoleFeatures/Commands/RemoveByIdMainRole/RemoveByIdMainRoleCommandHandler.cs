using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveMainRole;

public sealed class RemoveByIdMainRoleCommandHandler : ICommandHandler<RemoveByIdMainRoleCommand, RemoveByIdMainRoleCommandResponse>
{
    private readonly IMainRoleService _mainRoleService;

    public RemoveByIdMainRoleCommandHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async Task<RemoveByIdMainRoleCommandResponse> Handle(RemoveByIdMainRoleCommand request, CancellationToken cancellationToken)
    {
        await _mainRoleService.RemoveByIdAsync(request.Id);
        return new();
    }
}
