using Microsoft.AspNetCore.Identity;

namespace ArrayELearnApi.Application.Interfaces.Auth
{
    public interface IUserRoleService
    {
        Task<bool> RoleExistsAsync(string role, CancellationToken cancellationToken);
        Task<IEnumerable<string>> GetAllRolesAsync(CancellationToken cancellationToken = default);
        Task<IdentityResult> CreateRoleAsync(string roleName, CancellationToken cancellationToken = default);
        Task<IdentityResult> DeleteRoleAsync(string roleName, CancellationToken cancellationToken = default);
        Task<IdentityResult> UpdateRoleNameAsync(string currentRoleName, string newRoleName, CancellationToken cancellationToken = default);

        Task AssignRoleAsync(string userId, string role);
        Task RemoveRoleAsync(string userId, string role);
        Task<IList<string>> GetUserRolesAsync(string userId);
        Task<bool> IsUserInRoleAsync(string userId, string role);
    }
}
