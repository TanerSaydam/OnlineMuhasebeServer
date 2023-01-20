using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.UCAFRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineMuhasebeServer.Persistance.Repositories.CompanyDbContext.UCAFRepositories
{
    public sealed class UCAFCommandRepository : CompanyDbCommandRepository<UniformChartOfAccount>, IUCAFCommandRepository
    {
    }
}
