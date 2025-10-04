using ArrayELearnApi.Domain.Entities.Domain;

namespace ArrayELearnApi.Application.Interfaces.Repositories
{
    public interface ISubmissionRepository
    {   
        Task<IEnumerable<Submission>> GetSubmissionsByAssignmentIdAsync(int assignmentId);
        Task<IEnumerable<Submission>> GetSubmissionsByUserIdAsync(string userId);
    }
}
