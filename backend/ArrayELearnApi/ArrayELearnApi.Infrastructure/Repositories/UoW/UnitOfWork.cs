using ArrayELearnApi.Application.Interfaces.Repositories.Base;
using ArrayELearnApi.Application.Interfaces.UoW;
using ArrayELearnApi.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace ArrayELearnApi.Infrastructure.Repositories.UoW
{
    internal class UnitOfWork<TContext>(TContext context) : IUnitOfWork where TContext : DbContext
    {
        private bool _disposed = false;

        public virtual IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(context);
        }

        public IDbTransaction BeginTransaction()
        {
            var transaction = context.Database.BeginTransaction();
            return transaction.GetDbTransaction();
        }

        // Real EF Core return value
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await context.SaveChangesAsync(cancellationToken);

        // Simplified commit that ignores return value
        public async Task CommitAsync(CancellationToken cancellationToken = default)
            => await context.SaveChangesAsync(cancellationToken);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // prevents finalizer from running
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // dispose managed resources
                    context.Dispose();
                }

                // dispose unmanaged resources here if any
                _disposed = true;
            }
        }

        // Asynchronous dispose
        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (!_disposed)
            {
                await context.DisposeAsync();
                _disposed = true;
            }
        }
    }
}
