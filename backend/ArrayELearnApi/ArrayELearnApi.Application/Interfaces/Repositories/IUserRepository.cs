using ArrayELearnApi.Application.Interfaces.Repositories.Base;
using ArrayELearnApi.Domain.Entities.Auth;

namespace ArrayELearnApi.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUser> {
        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> ExistsByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    }
}
