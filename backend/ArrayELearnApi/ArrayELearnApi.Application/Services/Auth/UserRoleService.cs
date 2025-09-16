using ArrayELearnApi.Application.Interfaces.Auth;
using Microsoft.AspNetCore.Identity;

namespace ArrayELearnApi.Application.Services.Auth
{
    public class UserRoleService(RoleManager<IdentityRole> roleManager) : IUserRoleService
    {
        public async Task<bool> RoleExistsAsync(string roleName, CancellationToken cancellationToken = default)
        {
            return await roleManager.RoleExistsAsync(roleName);
        }

        public async Task<IEnumerable<string>> GetAllRolesAsync(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(roleManager.Roles.Select(r => r.Name).ToList());
        }
        public async Task<IdentityResult> CreateRoleAsync(string roleName, CancellationToken cancellationToken = default)
        {
            if (await RoleExistsAsync(roleName, cancellationToken))
                return IdentityResult.Failed(new IdentityError { Description = $"Role '{roleName}' already exists." });
            var result = await roleManager.CreateAsync(new IdentityRole(roleName));
            return result;
        }
        public async Task<IdentityResult> DeleteRoleAsync(string roleName, CancellationToken cancellationToken = default)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
                return IdentityResult.Failed(new IdentityError { Description = $"Role '{roleName}' does not exist." });
            var result = await roleManager.DeleteAsync(role);
            return result;
        }
        public async Task<IdentityResult> UpdateRoleNameAsync(string currentRoleName, string newRoleName, CancellationToken cancellationToken = default)
        {
            var role = await roleManager.FindByNameAsync(currentRoleName);
            if (role == null)
                return IdentityResult.Failed(new IdentityError { Description = $"Role '{currentRoleName}' does not exist." });
            if (await RoleExistsAsync(newRoleName, cancellationToken))
                return IdentityResult.Failed(new IdentityError { Description = $"Role '{newRoleName}' already exists." });
            role.Name = newRoleName;
            var result = await roleManager.UpdateAsync(role);
            return result;
        }

        public Task AssignRoleAsync(string userId, string role)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRoleAsync(string userId, string role)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetUserRolesAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserInRoleAsync(string userId, string role)
        {
            throw new NotImplementedException();
        }
    }
}
