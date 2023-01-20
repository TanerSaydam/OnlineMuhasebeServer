using OnlineMuhasebeServer.Domain.Abstractions;
using System.Linq.Expressions;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext
{
    public interface ICompanyDbQueryRepository<T> : ICompanyDbRepository<T>, IQueryGenericRepository<T>
        where T : Entity
    {        
    }
}
