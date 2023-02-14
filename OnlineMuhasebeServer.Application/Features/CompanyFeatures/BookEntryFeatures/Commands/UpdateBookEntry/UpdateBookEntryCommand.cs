using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.UpdateBookEntry;

public sealed record UpdateBookEntryCommand(
    string Id,
    string CompanyId,
    string Type,
    string Description,
    string Date): ICommand<UpdateBookEntryCommandResponse>;
