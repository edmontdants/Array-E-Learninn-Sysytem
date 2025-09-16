using ArrayELearnApi.Application.Features.Auth.Commands;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ArrayELearnApi.Application.Validators.Auth
{
    internal sealed class AssignRolesRequestAsyncValidator : AbstractValidator<AssignRolesCommand>
    {
        public AssignRolesRequestAsyncValidator(RoleManager<IdentityRole> roleManager, UserRolesAsyncValidator userRolesAsyncValidator)
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required")
                ;

            RuleFor(x => x.UserRoles)
                .NotEmpty().WithMessage("At least one role is required")
                ;

            RuleForEach(x => x.UserRoles)
                .SetValidator(userRolesAsyncValidator)
                ;
        }
    }
}
