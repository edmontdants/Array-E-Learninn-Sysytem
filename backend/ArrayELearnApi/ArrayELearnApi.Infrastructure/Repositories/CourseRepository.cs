using ArrayELearnApi.Application.Interfaces.Repositories;
using ArrayELearnApi.Domain.Entities.Domain;
using ArrayELearnApi.Infrastructure.Persistence;
using ArrayELearnApi.Infrastructure.Repositories.Base;

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
