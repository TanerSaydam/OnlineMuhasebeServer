using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories;
using OnlineMuhasebeServer.Persistance.Context;
using System.Linq.Expressions;

namespace OnlineMuhasebeServer.Persistance.Repositories
{
    public class QueryRepository<T> : IQueryRepository<T>
        where T : Entity
    {
        private static readonly Func<CompanyDbContext, string, bool, Task<T>> GetByIdCompiled =
            EF.CompileAsyncQuery((CompanyDbContext context, string id, bool isTracking) =>
                isTracking == true 
                ? context.Set<T>().FirstOrDefault(p => p.Id == id) 
                : context.Set<T>().AsNoTracking().FirstOrDefault(p => p.Id == id));

        private static readonly Func<CompanyDbContext, bool, Task<T>> GetFirstCompiled =
           EF.CompileAsyncQuery((CompanyDbContext context, bool isTracking) =>
                isTracking == true 
                ?context.Set<T>().FirstOrDefault()
                :context.Set<T>().AsNoTracking().FirstOrDefault());

        private static readonly Func<CompanyDbContext, Expression<Func<T, bool>>,bool, Task<T>> GetFirstByExpiressionCompiled =
           EF.CompileAsyncQuery((CompanyDbContext context, Expression<Func<T, bool>> expression, bool isTracking) =>
                isTracking == true
                ? context.Set<T>().FirstOrDefault(expression)
                : context.Set<T>().AsNoTracking().FirstOrDefault(expression));

        private CompanyDbContext _context;
        public DbSet<T> Entity { get; set; }

        public void SetDbContextInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
            Entity = _context.Set<T>();
        }

        public IQueryable<T> GetAll(bool isTracking = true)
        {
            var result = Entity.AsQueryable();
            if (!isTracking)
                result = result.AsNoTracking();
            return result;
        }

        public async Task<T> GetById(string id, bool isTracking = true)
        {            
            return await GetByIdCompiled(_context, id,isTracking);
        }

        public async Task<T> GetFirst(bool isTracking = true)
        {
            return await GetFirstCompiled(_context, isTracking);
        }

        public async Task<T> GetFirstByExpiression(Expression<Func<T, bool>> expression, bool isTracking = true)
        {
            return await GetFirstByExpiressionCompiled(_context, expression, isTracking);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true)
        {
            var result = Entity.Where(expression);
            if(!isTracking)
                result = result.AsNoTracking();
            return result;
        }
    }
}
