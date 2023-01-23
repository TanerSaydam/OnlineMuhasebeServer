using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.RemoveByIdMainRoleAndUserRL;

public sealed record RemoveByIdMainRoleAndUserRLCommand(
    string Id): ICommand<RemoveByIdMainRoleAndUserRLCommandResponse>;
