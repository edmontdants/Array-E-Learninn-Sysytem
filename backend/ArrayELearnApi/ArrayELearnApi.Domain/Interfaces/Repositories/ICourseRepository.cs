using ArrayELearnApi.Domain.Entities.Domain;

namespace ArrayELearnApi.Domain.Interfaces.Repositories
{
    public interface ICourseRepository : IRepository<Course> {
        Task<IEnumerable<Course>> GetCoursesByUserIdAsync(string userId);
    }
}
