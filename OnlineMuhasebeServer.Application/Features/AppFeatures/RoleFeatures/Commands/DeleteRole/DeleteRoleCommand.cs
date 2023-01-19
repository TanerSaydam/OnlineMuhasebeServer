using MediatR;
using OnlineMuhasebeServer.Application.Messaging;
using System.Windows.Input;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole
{
    public sealed record DeleteRoleCommand(
        string Id)
        : ICommand<DeleteRoleCommandResponse>;
}
