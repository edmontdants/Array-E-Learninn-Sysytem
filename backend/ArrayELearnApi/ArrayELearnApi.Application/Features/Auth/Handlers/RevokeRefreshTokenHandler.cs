using ArrayELearnApi.Application.Features.Auth.Commands;
using ArrayELearnApi.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArrayELearnApi.Application.Features.Auth.Handlers
{
    internal sealed class RevokeRefreshTokenHandler(IRefreshTokenRepository refreshTokenRepo, ILogger<RevokeRefreshTokenHandler> logger) : IRequestHandler<RevokeRefreshTokenCommand, bool>
    {
        public async Task<bool> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await refreshTokenRepo.RevokeAsync(request.RefreshToken, cancellationToken);
                await refreshTokenRepo.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled error in RevokeRefreshTokenHandler {Exception}", ex);
                return false;
            }
        }
    }
}
