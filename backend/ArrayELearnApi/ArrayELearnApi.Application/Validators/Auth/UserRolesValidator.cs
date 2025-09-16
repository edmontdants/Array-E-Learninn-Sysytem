using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ArrayELearnApi.Application.Validators.Auth
{
    internal sealed class UserRolesAsyncValidator : AbstractValidator<string>
    {
        public UserRolesAsyncValidator(RoleManager<IdentityRole> roleManager)
        {
            RuleFor(role => role)
            .MustAsync(async (role, ct) =>
                await roleManager.RoleExistsAsync(role))
            .WithMessage(role => $"Role '{role}' does not exist in the system");
            ;
        }
    }
}
