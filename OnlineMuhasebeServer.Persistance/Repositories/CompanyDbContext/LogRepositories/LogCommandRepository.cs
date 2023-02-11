using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.CompanyDbContext;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.LogRepositories;

namespace OnlineMuhasebeServer.Persistance.Repositories.CompanyDbContext.LogRepositories;

public class LogCommandRepository : CompanyDbCommandRepository<Log>, ILogCommandRepository
{

}
