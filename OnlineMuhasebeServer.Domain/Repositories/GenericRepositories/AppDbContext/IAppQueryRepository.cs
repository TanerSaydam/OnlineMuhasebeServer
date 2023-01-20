using OnlineMuhasebeServer.Domain.Abstractions;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.AppDbContext;

public interface IAppQueryRepository<T> : IQueryGenericRepository<T>, IRepository<T>
    where T:Entity
{
}
