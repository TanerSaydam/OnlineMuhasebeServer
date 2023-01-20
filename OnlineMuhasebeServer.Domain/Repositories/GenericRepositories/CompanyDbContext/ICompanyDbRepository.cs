using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext
{
    public interface ICompanyDbRepository<T> : IRepository<T>
        where T : Entity
    {
        void SetDbContextInstance(DbContext context);        
    }
}
