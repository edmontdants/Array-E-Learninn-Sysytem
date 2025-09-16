using ArrayELearnApi.Domain.Interfaces.Repositories;
using ArrayELearnApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace ArrayELearnApi.Infrastructure.Repositories
{
    internal class UnitOfWork(ApplicationDbContext context, IServiceProvider serviceProvider) : IUnitOfWork
    {
        private bool _disposed = false;

        // entity-specific derived Repos
        public IUserRepository userRepository { get; } = serviceProvider.GetRequiredService<IUserRepository>();
        public ICourseRepository courseRepository => serviceProvider.GetRequiredService<ICourseRepository>();
        public ISubmissionRepository submissionRepository => serviceProvider.GetRequiredService<ISubmissionRepository>();
        public IRefreshTokenRepository refreshTokenRepository => serviceProvider.GetRequiredService<IRefreshTokenRepository>();

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            // Try specialized repo first then falls back to Generic
            var specializedRepo = serviceProvider.GetService<IRepository<TEntity>>();
            if (specializedRepo is not null)
                return specializedRepo;
            
            // throws if not found
            return serviceProvider.GetRequiredService<IRepository<TEntity>>();
        }

        public IDbTransaction BeginTransaction()
        {
            var transaction = context.Database.BeginTransaction();
            return transaction.GetDbTransaction();
        }

        // Real EF Core return value
        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
            => await context.SaveChangesAsync(ct);

        // Simplified commit that ignores return value
        public async Task CommitAsync(CancellationToken ct = default)
            => await context.SaveChangesAsync(ct);

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
