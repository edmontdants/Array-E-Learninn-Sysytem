using ArrayELearnApi.Domain.Entities.Domain;
using ArrayELearnApi.Domain.Interfaces.Repositories;
using ArrayELearnApi.Infrastructure.Persistence;

namespace ArrayELearnApi.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context) { }

        public Task<IEnumerable<Course>> GetCoursesByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
