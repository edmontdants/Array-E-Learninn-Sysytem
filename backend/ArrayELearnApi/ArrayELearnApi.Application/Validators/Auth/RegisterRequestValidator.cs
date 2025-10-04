using ArrayELearnApi.Application.Features.Auth.Commands;
using ArrayELearnApi.Application.Interfaces.UoW;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ArrayELearnApi.Application.Validators.Auth
{
    internal sealed class RegisterRequestAsyncValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterRequestAsyncValidator(IApplicationUnitOfWork uow, RoleManager<IdentityRole> roleManager, UserRolesAsyncValidator userRolesAsyncValidator)
        {
            var userRepository = uow.userRepository;

            RuleFor(x => x)
                .Must(x => !string.IsNullOrEmpty(x.Email) || !string.IsNullOrEmpty(x.UserName))
                    .WithMessage("Either Email or Username must be provided.")
                ;

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                    .WithMessage("Inavalid email format")
                .MustAsync(async (email, ct) => !await userRepository.ExistsByEmailAsync(email, ct))
                    .WithMessage("Email is already registered")
                ;
            
            RuleFor(x => x.UserName)
                .MustAsync(async (userName, ct) => !await userRepository.ExistsByUserNameAsync(userName, ct))
                .When(x => !string.IsNullOrEmpty(x.UserName))
                    .WithMessage("UserName already exists")
                ;

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage("Password is required")
                .MinimumLength(6)
                    .WithMessage("Password must be at least 6 characters long")
                ;
            
            //RuleFor(x => x.ConfirmPassword)
            //    .Equal(x => x.Password).WithMessage("Confirm Password doesn't match")
            //    ;

            RuleForEach(x => x.UserRoles)
                .SetValidator(userRolesAsyncValidator)
                ;


        }
    }
}
