using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.RemoveByIdBookEntry;

public sealed record RemoveByIdBookEntryCommand(
    string Id,
    string CompanyId): ICommand<RemoveByIdBookEntryCommandResponse>;
