using ArrayELearnApi.Domain.Entities.Domain;
using ArrayELearnApi.Domain.Interfaces.Repositories;
using ArrayELearnApi.Infrastructure.Persistence;

namespace ArrayELearnApi.Infrastructure.Repositories
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ApplicationDbContext context) : base(context) { }
    }
}
