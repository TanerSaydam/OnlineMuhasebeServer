using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Queries.GetAllBookEntry;

public sealed class GetAllBookEntryQueryHandler : IQueryHandler<GetAllBookEntryQuery, PaginationResult<GetAllBookEntryQueryResponse>>
{
    private readonly IBookEntryService _bookEntryService;    

    public GetAllBookEntryQueryHandler(IBookEntryService bookEntryService)
    {
        _bookEntryService = bookEntryService; 
    }

    public async Task<PaginationResult<GetAllBookEntryQueryResponse>> Handle(GetAllBookEntryQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<BookEntry> result = await _bookEntryService.GetAllAsync(request.CompanyId, request.PageNumber, request.PageSize, request.Year);

        int count = _bookEntryService.GetCount(request.CompanyId);

        PaginationResult<GetAllBookEntryQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllBookEntryQueryResponse(
                s.Id,
                s.BookEntryNumber,
                s.Date,
                s.Description,
                s.Type,
                0,
                0)).ToList());

        return newResult;
    }
}
