using ArrayELearnApi.Application.Interfaces.UoW;
using ArrayELearnApi.Infrastructure.Persistence;
using ArrayELearnApi.Infrastructure.Repositories.UoW;

namespace ArrayELearnApi.Infrastructure.Repositories
{
    internal class LoggingUnitOfWork(ApplicationDbContext context) : UnitOfWork<ApplicationDbContext>(context),
                                                                     ILoggingUnitOfWork
    {
        // entity-specific derived Repos
        // repos here...
    }
}
