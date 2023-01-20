using Microsoft.EntityFrameworkCore;

namespace OnlineMuhasebeServer.Domain
{
    public interface IUnitOfWork
    {
        void SetDbContextInstance(DbContext context);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
