using ArrayELearnApi.Application.DTOs.Auth;
using ArrayELearnApi.Application.Features.Auth.Commands;
using ArrayELearnApi.Application.Interfaces.Auth;
using ArrayELearnApi.Application.Interfaces.Repositories;
using ArrayELearnApi.Domain.Entities;
using ArrayELearnApi.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ArrayELearnApi.Application.Features.Auth.Handlers
{
    internal sealed class LoginHandler(UserManager<ApplicationUser> userManager, IRefreshTokenRepository refreshTokenRepo, IJwtTokenGenerator JwtTokenGenerator, ILogger<LoginHandler> logger) : IRequestHandler<LoginCommand, AuthResponse>
    {
        public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ApplicationUser user;
                if (!string.IsNullOrEmpty(request.Email))
                    user = await userManager.FindByEmailAsync(request.Email);
                else
                    user = await userManager.FindByNameAsync(request.UserName);

                if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
                    return new AuthResponse { IsSuccessed = false, Message = "User doesn't exist or Invalid credentials" };

                var jwtToken = await JwtTokenGenerator.GenerateJwtTokenAsync(user);

                var refreshToken = new RefreshToken
                {
                    Token = Guid.NewGuid().ToString(),
                    UserId = user.Id,
                    Expires = DateTime.Now.AddDays(30),
                    IsRevoked = false,
                    IsUsed = false
                };

                refreshTokenRepo.Add(refreshToken);
                await refreshTokenRepo.SaveChangesAsync();

                return new AuthResponse { IsSuccessed = true, Message = "User logged in successfully", AccessToken = jwtToken, RefreshToken = refreshToken.Token };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in LoginHandler {@ex}", ex);
                throw;
            }
            
        }
    }
}
