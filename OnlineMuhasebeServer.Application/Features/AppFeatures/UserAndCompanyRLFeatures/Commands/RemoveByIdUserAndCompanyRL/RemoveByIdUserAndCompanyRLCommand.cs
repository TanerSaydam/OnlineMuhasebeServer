using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL;

public sealed record RemoveByIdUserAndCompanyRLCommand(
    string Id): ICommand<RemoveByIdUserAndCompanyRLCommandResponse>;
