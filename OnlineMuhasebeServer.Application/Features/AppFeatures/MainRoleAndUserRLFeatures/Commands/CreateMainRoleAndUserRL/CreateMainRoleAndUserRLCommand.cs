using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRL;

public sealed record CreateMainRoleAndUserRLCommand(
    string UserId,
    string MainRoleId,
    string CompanyId) : ICommand<CreateMainRoleAndUserRLCommandResponse>;

