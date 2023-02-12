namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Queries.GetAllBookEntry;

public sealed record GetAllBookEntryQueryResponse(
    string Id,
    string BookEntryNumber,
    DateTime Date,
    string Description,
    string Type,
    decimal Debt,
    decimal Credit);

