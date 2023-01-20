using Microsoft.EntityFrameworkCore;

namespace OnlineMuhasebeServer.Domain.UnitOfWorks;

public interface ICompanyDbUnitOfWork : IUnitOfWork
{
    void SetDbContextInstance(DbContext context);
}
