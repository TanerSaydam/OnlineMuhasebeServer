using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext;


namespace OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.BookEntryRepositories;

public interface IBookEntryCommandRepository : ICompanyDbCommandRepository<BookEntry>
{

}
