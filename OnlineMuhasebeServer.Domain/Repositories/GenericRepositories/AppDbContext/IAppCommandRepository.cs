using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.AppDbContext;

public interface IAppCommandRepository<T> : ICommandGenericRepository<T>, IRepository<T>
    where T : Entity
{    
}
