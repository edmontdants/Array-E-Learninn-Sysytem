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
    internal sealed class RefreshTokenHandler(UserManager<ApplicationUser> userManager, IRefreshTokenRepository refreshTokenRepo, IJwtTokenGenerator JwtTokenGenerator, ILogger<RefreshTokenHandler> logger) : IRequestHandler<RefreshTokenCommand, AuthResponse>
    {
        public async Task<AuthResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken = default)
        {
            try
            {
                var storedToken = await refreshTokenRepo.GetByTokenAsync(request.RefreshToken, cancellationToken);
                if (storedToken == null || storedToken.IsRevoked || storedToken.IsUsed || storedToken.Expires < DateTime.Now)
                    return null;

                storedToken.IsUsed = true;
                await refreshTokenRepo.SaveChangesAsync();

                var user = await userManager.FindByIdAsync(storedToken.UserId);
                if (user == null)
                {
                    logger.LogError("User not found: {UserID}", storedToken.UserId);
                    return new AuthResponse() { Message = "User not found", IsSuccessed = false };
                }

                var newJwt = await JwtTokenGenerator.GenerateJwtTokenAsync(user);
                var newRefreshToken = new RefreshToken { Token = Guid.NewGuid().ToString(), UserId = storedToken.UserId, Expires = DateTime.Now.AddDays(7) };
                refreshTokenRepo.Add(newRefreshToken);
                await refreshTokenRepo.SaveChangesAsync();

                return new AuthResponse { AccessToken = newJwt, RefreshToken = newRefreshToken.Token };
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                // You can also rethrow the exception or handle it as needed
                // For now, we will just rethrow it
                // Note: In production code, consider logging the exception
                // and returning a more user-friendly error message.
                // This is a placeholder for actual logging logic
                logger.LogError(ex, "Unhandled error in RefreshTokenHandler {Exception}", ex);
                // Rethrow the exception to be handled by the global exception handler
                // or middleware.
                throw;
            }
        }
    }
}
