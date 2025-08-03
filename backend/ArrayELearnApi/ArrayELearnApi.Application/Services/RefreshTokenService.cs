using ArrayELearnApi.Domain.Interfaces;

namespace ArrayELearnApi.Application.Services
{
    public class RefreshTokenService
    {
        private readonly IRefreshTokenRepository _repository;

        public RefreshTokenService(IRefreshTokenRepository repository)
        {
            _repository = repository;
        }

        public async Task CleanupExpiredTokensAsync()
        {
            var expired = await _repository.GetExpiredTokensAsync();
            foreach (var token in expired)
            {
                // Remove or mark as revoked
                token.IsRevoked = true;
            }
            await _repository.SaveChangesAsync();
        }
    }
}
