using ArrayELearnApi.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Application.Interfaces.UoW;

namespace ArrayELearnApi.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var unitOfWork = services.GetRequiredService<IApplicationUnitOfWork>();

            string[] roles = [UserRole.Owner, UserRole.Admin, UserRole.Instructor, UserRole.Student];

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Add default admin user
            var ownerEmail = "owner@arrayelearn.com";
            var ownerUserName = "owner@arrayelearn";
            var ownerFirstName = "owner";
            var ownerLastName = "arrayelearn";
            var ownerUser = await userManager.FindByEmailAsync(ownerEmail);
            if (ownerUser == null)
            {
                ownerUser = new ApplicationUser { UserName = ownerUserName, Email = ownerEmail, EmailConfirmed = true };
                ownerUser.CREATEDBY = ownerUser.Id;
                await userManager.CreateAsync(ownerUser, "Owner@123");
                await userManager.AddToRoleAsync(ownerUser, UserRole.Owner);
            }

            var statusRepo = unitOfWork.Repository<Domain.Entities.Base.Status>();
            var status = await statusRepo.GetAllAsync();

            string[] Status = [Domain.Constants.Status.Active, Domain.Constants.Status.InActive ];

            if (!status.Any())
            {
                var activeStatus = new Domain.Entities.Base.Status
                {
                    ID = 1,
                    Name = Domain.Constants.Status.Active,
                    CREATEDBY = ownerUser.Id
                };
                statusRepo.Add(activeStatus);

                var inActiveStatus = new Domain.Entities.Base.Status
                {
                    ID = 2,
                    Name = Domain.Constants.Status.InActive,
                    CREATEDBY = ownerUser.Id
                };
                statusRepo.Add(inActiveStatus);

                await unitOfWork.SaveChangesAsync();
            }
        }
    }
}
