using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;

public sealed record CreateMainRoleCommand(
    string Title,
    bool IsRoleCreatedByAdmin = false,
    string CompanyId = null) : ICommand<CreateMainRoleCommandResponse>;
