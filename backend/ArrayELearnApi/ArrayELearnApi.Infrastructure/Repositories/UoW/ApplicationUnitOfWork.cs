using ArrayELearnApi.Application.Interfaces.Repositories;
using ArrayELearnApi.Application.Interfaces.UoW;
using ArrayELearnApi.Infrastructure.Persistence;
using ArrayELearnApi.Infrastructure.Repositories.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace ArrayELearnApi.Infrastructure.Repositories
{
    internal class ApplicationUnitOfWork(ApplicationDbContext context,
                                         IServiceProvider provider) : UnitOfWork<ApplicationDbContext>(context),
                                                                      IApplicationUnitOfWork
    {
        // entity-specific derived Repos
        public IUserRepository userRepository { get; } = provider.GetRequiredService<IUserRepository>();
        public IStudentRepository studentRepository { get; } = provider.GetRequiredService<IStudentRepository>();
        public IInstructorRepository instructorRepository { get; } = provider.GetRequiredService<IInstructorRepository>();
        public ICourseRepository courseRepository => provider.GetRequiredService<ICourseRepository>();
        public ISubmissionRepository submissionRepository => provider.GetRequiredService<ISubmissionRepository>();
        public IRefreshTokenRepository refreshTokenRepository => provider.GetRequiredService<IRefreshTokenRepository>();
    }
}
