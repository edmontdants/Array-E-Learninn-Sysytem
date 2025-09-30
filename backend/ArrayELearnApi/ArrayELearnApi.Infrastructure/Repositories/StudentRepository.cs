using ArrayELearnApi.Domain.Entities.Domain;
using ArrayELearnApi.Domain.Interfaces.Repositories;
using ArrayELearnApi.Infrastructure.Persistence;

namespace ArrayELearnApi.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context) { }
    }
}
