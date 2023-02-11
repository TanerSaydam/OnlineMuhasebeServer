using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext;


namespace OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.LogRepositories;

public interface ILogCommandRepository : ICompanyDbCommandRepository<Log>
{

}
