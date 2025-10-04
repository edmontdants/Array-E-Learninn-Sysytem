using ArrayELearnApi.Application.Interfaces.Repositories;

namespace ArrayELearnApi.Application.Interfaces.UoW
{
    public interface IApplicationUnitOfWork : IUnitOfWork, IDisposable, IAsyncDisposable
    {
        IUserRepository userRepository { get; }
        IStudentRepository studentRepository { get; }
        IInstructorRepository instructorRepository { get; }
        ICourseRepository courseRepository { get; }
        ISubmissionRepository submissionRepository { get; }
        IRefreshTokenRepository refreshTokenRepository { get; }
    }
}
