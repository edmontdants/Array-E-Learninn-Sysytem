using ArrayELearnApi.Application.Interfaces.Repositories.Base;
using System.Data;

namespace ArrayELearnApi.Application.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        IDbTransaction BeginTransaction();

        // Full SaveChanges with return value (for infra layer / logging / auditing)
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        // Simplified commit (for app/business layer when count doesn’t matter)
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
