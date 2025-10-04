using ArrayELearnApi.Application.Interfaces.Repositories.Base;
using ArrayELearnApi.Domain.Entities.Domain;

namespace ArrayELearnApi.Application.Interfaces.Repositories
{
    public interface ICourseRepository : IRepository<Course> {
        Task<IEnumerable<Course>> GetCoursesByUserIdAsync(string userId);
    }
}
