using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.UnitOfWorks;

public sealed class AppUnitOfWork : IAppUnitOfWork
{
    private readonly AppDbContext _context;

    public AppUnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
       int count = await _context.SaveChangesAsync(cancellationToken);
       return count;
    }
}
