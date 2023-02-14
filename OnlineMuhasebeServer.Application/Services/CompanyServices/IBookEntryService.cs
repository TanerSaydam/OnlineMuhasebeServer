
using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Services.CompanyServices;

public interface IBookEntryService
{
    Task<string> GetNewBookEntryNumber(string companyId);
    Task AddAsync(string companyId, BookEntry bookEntry, CancellationToken cancellationToken);
    Task<BookEntry> RemoveByIdAsync(string id, string companyId);
    Task<PaginationResult<BookEntry>> GetAllAsync(string companyId, int pageNumber, int pageSize, int year);
    int GetCount(string companyId);
    Task<BookEntry> GetByIdAsync(string id, string companyId);
    Task<BookEntry> UpdateAsync(BookEntry bookEntry, string companyId);
}
