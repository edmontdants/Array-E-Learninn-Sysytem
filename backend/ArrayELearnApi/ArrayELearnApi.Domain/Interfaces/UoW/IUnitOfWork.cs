using ArrayELearnApi.Domain.Interfaces.Repositories;
using System.Data;

namespace ArrayELearnApi.Domain.Interfaces.UoW
{
    public interface IUnitOfWork<TContext> : IDisposable, IAsyncDisposable
    {
        IUserRepository userRepository { get; }
        IStudentRepository studentRepository { get; }
        IInstructorRepository instructorRepository { get; }
        ICourseRepository courseRepository { get; }
        ISubmissionRepository submissionRepository { get; }
        IRefreshTokenRepository refreshTokenRepository { get; }

        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        IDbTransaction BeginTransaction();

        // Full SaveChanges with return value (for infra layer / logging / auditing)
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        // Simplified commit (for app/business layer when count doesn’t matter)
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
