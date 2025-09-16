using ArrayELearnApi.Application.Features.Auth.Commands;
using FluentValidation;

namespace ArrayELearnApi.Application.Validators.Auth
{
    internal sealed class LoginRequestValidator : AbstractValidator<LoginCommand>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x)
                .Must(x => !string.IsNullOrEmpty(x.Email) || !string.IsNullOrEmpty(x.UserName))
                    .WithMessage("Either Email or Username must be provided.")
                ;

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                    .WithMessage("Invalid email format.")
                ;

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage("Password is required.")
                .MinimumLength(6)
                    .WithMessage("Password must be at least 6 characters long.")
                ;
        }
    }
}
