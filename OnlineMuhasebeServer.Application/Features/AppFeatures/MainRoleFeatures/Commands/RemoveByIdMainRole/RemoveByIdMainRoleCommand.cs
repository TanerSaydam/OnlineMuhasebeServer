using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveMainRole
{
    public sealed record RemoveByIdMainRoleCommand(
        string Id): ICommand<RemoveByIdMainRoleCommandResponse>;
}
