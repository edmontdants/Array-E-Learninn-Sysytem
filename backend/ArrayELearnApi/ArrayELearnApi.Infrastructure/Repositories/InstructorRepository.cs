using ArrayELearnApi.Application.Interfaces.Repositories;
using ArrayELearnApi.Domain.Entities.Domain;
using ArrayELearnApi.Infrastructure.Persistence;
using ArrayELearnApi.Infrastructure.Repositories.Base;

namespace ArrayELearnApi.Infrastructure.Repositories
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ApplicationDbContext context) : base(context) { }
    }
}
