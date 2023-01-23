using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRoleRL;

public sealed record CreateMainRoleAndRoleRLCommand(
    string RoleId,
    string MainRoleId) : ICommand<CreateMainRoleAndRoleRLCommandResponse>;

