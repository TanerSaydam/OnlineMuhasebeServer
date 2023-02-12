
using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Services.CompanyServices;

public interface IBookEntryService
{
    Task<string> GetNewBookEntryNumber(string companyId);
    Task AddAsync(string companyId, BookEntry bookEntry, CancellationToken cancellationToken);
    Task<PaginationResult<BookEntry>> GetAllAsync(string companyId, int pageNumber, int pageSize);
    int GetCount(string companyId);
}
