using ArrayELearnApi.Application.Features.Auth.Commands;
using ArrayELearnApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ArrayELearnApi.Application.Features.Auth.Handlers
{
    public class RegisterRequestHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterRequestHandler(UserManager<ApplicationUser> userManager) => _userManager = userManager;

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser { UserName = request.Email, Email = request.Email };
            var result = await _userManager.CreateAsync(user, request.Password);
            return result.Succeeded;
        }
    }
}
