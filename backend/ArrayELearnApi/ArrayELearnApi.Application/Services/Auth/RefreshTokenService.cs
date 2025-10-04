using ArrayELearnApi.Application.Interfaces.Repositories;

namespace ArrayELearnApi.Application.Services.Auth
{
    public class RefreshTokenService(IRefreshTokenRepository repository)
    {
        public async Task CleanupExpiredTokensAsync(CancellationToken cancellationToken)
        {
            var expired = await repository.GetExpiredTokensAsync(cancellationToken);
            foreach (var token in expired)
            {
                // Remove or mark as revoked
                token.IsRevoked = true;
            }
            await repository.SaveChangesAsync();
        }
    }
}
