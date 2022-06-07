using Microsoft.EntityFrameworkCore.Storage;
using News.Database.Common;

namespace News.Database
{
    public interface IUnitOfWork
    {
        void Add<T>(T entity) where T : AuditableEntity;
        void AddRange<T>(IEnumerable<T> entities) where T : AuditableEntity;
        Task<IDbContextTransaction> BeginTransactionAsync();
        void Commit();
        Task CommitAsync();
        void Dispose();
        IQueryable<T> Get<T>() where T : class;
        void Remove<T>(T entity) where T : class;
        void RemoveRange<T>(IEnumerable<T> entities) where T : class;
        void Update<T>(T entity) where T : AuditableEntity;
    }
}