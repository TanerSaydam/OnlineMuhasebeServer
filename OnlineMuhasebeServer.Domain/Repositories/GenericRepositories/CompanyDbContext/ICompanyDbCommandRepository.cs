using OnlineMuhasebeServer.Domain.Abstractions;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext;

public interface ICompanyDbCommandRepository<T> : ICompanyDbRepository<T>, ICommandGenericRepository<T>
    where T : Entity
{   
}
