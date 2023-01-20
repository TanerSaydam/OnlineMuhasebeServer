using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.AppDbContext;

namespace OnlineMuhasebeServer.Domain.Repositories.AppDbContext.CompanyRepositories;

public interface ICompanyCommandRepository : IAppCommandRepository<Company>
{
}
