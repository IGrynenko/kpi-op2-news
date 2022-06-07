using Microsoft.EntityFrameworkCore.Storage;
using News.Database.Common;

namespace News.Database
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MainDbContext _dbContext;

        public UnitOfWork(MainDbContext dbContext) => _dbContext = dbContext;

        public void Add<T>(T entity)
            where T : AuditableEntity
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            _dbContext.Set<T>().Add(entity);
        }

        public void AddRange<T>(IEnumerable<T> entities)
            where T : AuditableEntity
        {
            foreach (var entity in entities)
            {
                entity.CreatedAt = DateTime.UtcNow;
                entity.UpdatedAt = DateTime.UtcNow;
            }

            _dbContext.Set<T>().AddRange(entities);
        }

        public void Update<T>(T entity)
            where T : AuditableEntity
        {
            entity.UpdatedAt = DateTime.UtcNow;

            _dbContext.Set<T>().Update(entity);
        }

        public void Remove<T>(T entity)
            where T : class
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void RemoveRange<T>(IEnumerable<T> entities)
            where T : class
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public IQueryable<T> Get<T>()
            where T : class
        {
            return _dbContext.Set<T>();
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return _dbContext.Database.BeginTransactionAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
