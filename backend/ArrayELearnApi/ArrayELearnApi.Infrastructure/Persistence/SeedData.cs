using ArrayELearnApi.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ArrayELearnApi.Domain.Entities.Auth;

namespace ArrayELearnApi.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = [UserRole.Admin, UserRole.Instructor, UserRole.Student];

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Add default admin user
            var ownerEmail = "owner@arrayelearn.com";
            var ownerUserName = "owner@arrayelearn";
            var ownerUser = await userManager.FindByEmailAsync(ownerEmail);
            if (ownerUser == null)
            {
                ownerUser = new ApplicationUser { UserName = ownerUserName, Email = ownerEmail, EmailConfirmed = true };
                await userManager.CreateAsync(ownerUser, "Owner@123");
                await userManager.AddToRoleAsync(ownerUser, UserRole.Owner);
            }
        }
    }
}
