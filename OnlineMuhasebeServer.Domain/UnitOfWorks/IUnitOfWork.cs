namespace OnlineMuhasebeServer.Domain.UnitOfWorks;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
