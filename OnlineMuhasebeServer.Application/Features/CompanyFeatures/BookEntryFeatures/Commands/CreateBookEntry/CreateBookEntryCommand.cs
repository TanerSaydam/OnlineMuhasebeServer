using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry;

public sealed record CreateBookEntryCommand(
    string CompanyId,
    string Type,
    string Description,
    string Date): ICommand<CreateBookEntryCommandResponse>;
