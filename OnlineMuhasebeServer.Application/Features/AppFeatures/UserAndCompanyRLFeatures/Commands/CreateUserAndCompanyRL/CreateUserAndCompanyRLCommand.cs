using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;

public sealed record CreateUserAndCompanyRLCommand(
    string AppUserId,
    string CompanyId) : ICommand<CreateUserAndCompanyRLCommandResponse>;

