using ArrayELearnApi.Application.Interfaces.Auth;
using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ArrayELearnApi.Infrastructure.Services.Auth
{
    public class UserClaimsResolverService : IUserClaimsResolverService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        public UserClaimsResolverService(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<IList<Claim>> GetUserClaimsAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            var claims = await _userManager.GetClaimsAsync(user);

            // Optionally, resolve dynamic claims from your own tables (e.g., permissions)
            //var permissions = await _dbContext.UserPermissions
            //    .Where(p => p.UserId == userId)
            //    .Select(p => new Claim("Permission", p.PermissionKey))
            //    .ToListAsync();

            //claims = claims.Concat(permissions).ToList();

            return claims.ToList();
        }
    }
}
