using ArrayELearnApi.Domain.Entities.Domain;
using ArrayELearnApi.Domain.Interfaces.Repositories;
using ArrayELearnApi.Infrastructure.Persistence;

namespace ArrayELearnApi.Infrastructure.Repositories
{
    public class SubmissionRepository : Repository<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(ApplicationDbContext context) : base(context) { }

        public Task<IEnumerable<Submission>> GetSubmissionsByAssignmentIdAsync(int assignmentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Submission>> GetSubmissionsByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
