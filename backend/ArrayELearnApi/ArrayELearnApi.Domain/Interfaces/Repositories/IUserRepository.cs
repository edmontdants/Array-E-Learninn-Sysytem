using ArrayELearnApi.Domain.Entities.Auth;

namespace ArrayELearnApi.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUser> {
        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> ExistsByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    }
}
