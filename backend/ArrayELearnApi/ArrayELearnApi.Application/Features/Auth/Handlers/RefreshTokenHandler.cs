using ArrayELearnApi.Application.DTOs;
using ArrayELearnApi.Application.Helpers;
using ArrayELearnApi.Domain.Entities;
using ArrayELearnApi.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace ArrayELearnApi.Application.Commands
{
    public class RefreshTokenRequestHandler : IRequestHandler<RefreshTokenCommand, LoginResultDto>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepo;
        private readonly IJwtTokenGenerator _IJwtTokenGenerator;
        private readonly UserManager<ApplicationUser> _userManager;

        public RefreshTokenRequestHandler(UserManager<ApplicationUser> userManager, IRefreshTokenRepository refreshTokenRepo, IJwtTokenGenerator IJwtTokenGenerator)
        {
            _refreshTokenRepo = refreshTokenRepo;
            _IJwtTokenGenerator = IJwtTokenGenerator;
            _userManager = userManager;
        }

        public async Task<LoginResultDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var storedToken = await _refreshTokenRepo.GetByTokenAsync(request.RefreshToken);
            if (storedToken == null || storedToken.IsRevoked || storedToken.IsUsed || storedToken.Expires < DateTime.UtcNow)
                return null;

            storedToken.IsUsed = true;
            await _refreshTokenRepo.SaveChangesAsync();

            var user = await _userManager.FindByIdAsync(storedToken.UserId);
            var roles = await _userManager.GetRolesAsync(user);
            var newJwt = _IJwtTokenGenerator.GenerateJwtToken(user, roles);
            var newRefreshToken = new RefreshToken { Token = Guid.NewGuid().ToString(), UserId = storedToken.UserId, Expires = DateTime.UtcNow.AddDays(7) };
            await _refreshTokenRepo.AddAsync(newRefreshToken);
            await _refreshTokenRepo.SaveChangesAsync();

            return new LoginResultDto { Token = newJwt, RefreshToken = newRefreshToken.Token };
        }
    }

}
