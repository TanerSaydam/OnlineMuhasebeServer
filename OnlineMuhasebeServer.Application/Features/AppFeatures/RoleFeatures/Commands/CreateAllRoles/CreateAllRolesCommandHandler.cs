using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Domain.Roles;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRoles;

public sealed class CreateAllRolesCommandHandler : ICommandHandler<CreateAllRolesCommand, CreateAllRolesCommandResponse>
{
    private readonly IRoleService _roleService;

    public CreateAllRolesCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<CreateAllRolesCommandResponse> Handle(CreateAllRolesCommand request, CancellationToken cancellationToken)
    {
        IList<AppRole> originalRoleList = RoleList.GetStaticRoles();
        IList<AppRole> newRoleList = new List<AppRole>();

        foreach (var role in originalRoleList)
        {
            AppRole checkRole = await _roleService.GetByCode(role.Code);
            if (checkRole == null) newRoleList.Add(role);
        }

        await _roleService.AddRangeAsync(newRoleList);
        return new();
    }
}
