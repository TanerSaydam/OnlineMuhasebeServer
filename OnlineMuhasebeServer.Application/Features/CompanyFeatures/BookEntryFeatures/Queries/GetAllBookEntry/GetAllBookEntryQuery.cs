using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Queries.GetAllBookEntry;

public sealed record GetAllBookEntryQuery(
    string CompanyId,
    int Year,
    int PageNumber = 1,
    int PageSize = 10): IQuery<PaginationResult<GetAllBookEntryQueryResponse>>;
