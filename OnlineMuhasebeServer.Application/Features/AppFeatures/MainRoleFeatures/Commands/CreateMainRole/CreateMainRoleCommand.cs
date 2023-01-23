using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;

public sealed record CreateMainRoleCommand(
    string Title,    
    string CompanyId = null) : ICommand<CreateMainRoleCommandResponse>;
