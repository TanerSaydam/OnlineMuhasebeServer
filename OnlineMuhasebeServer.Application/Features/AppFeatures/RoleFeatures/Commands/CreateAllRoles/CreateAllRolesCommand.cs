using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRoles;

public sealed record CreateAllRolesCommand() : ICommand<CreateAllRolesCommandResponse>;
