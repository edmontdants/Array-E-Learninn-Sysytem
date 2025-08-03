using ArrayELearnApi.Application.DTOs.Auth;
using ArrayELearnApi.Application.Features.Auth.Commands;
using ArrayELearnApi.Domain.Entities;
using ArrayELearnApi.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ArrayELearnApi.Application.Features.Auth.Handlers
{
    public class LoginRequestHandler : IRequestHandler<LoginCommand, LoginResultDto>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepo;
        private readonly IJwtTokenGenerator _IJwtTokenGenerator;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginRequestHandler(UserManager<ApplicationUser> userManager, IRefreshTokenRepository refreshTokenRepo, IJwtTokenGenerator IJwtTokenGenerator)
        {
            _refreshTokenRepo = refreshTokenRepo;
            _IJwtTokenGenerator = IJwtTokenGenerator;
            _userManager = userManager;
        }

        public async Task<LoginResultDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return null;

            var roles = await _userManager.GetRolesAsync(user);
            var jwtToken = _IJwtTokenGenerator.GenerateJwtToken(user, roles);

            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                UserId = user.Id,
                Expires = DateTime.UtcNow.AddDays(7),
                IsRevoked = false,
                IsUsed = false
            };

            await _refreshTokenRepo.AddAsync(refreshToken);
            await _refreshTokenRepo.SaveChangesAsync();

            return new LoginResultDto { Token = jwtToken, RefreshToken = refreshToken.Token };
        }
    }
}
