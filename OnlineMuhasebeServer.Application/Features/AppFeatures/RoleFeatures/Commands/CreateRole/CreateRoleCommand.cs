using MediatR;
using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole
{
    public sealed record CreateRoleCommand(
        string Code,
        string Name) : ICommand<CreateRoleCommandResponse>;
}
