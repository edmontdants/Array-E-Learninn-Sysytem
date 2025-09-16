using ArrayELearnApi.Domain.Entities.Auth;

namespace ArrayELearnApi.Domain.Interfaces.Repositories
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken>
    {
        Task<IEnumerable<RefreshToken>> GetExpiredTokensAsync(CancellationToken cancellationToken);
        Task RevokeAsync(string token, CancellationToken cancellationToken);
        Task<RefreshToken> GetByTokenAsync(string token, CancellationToken cancellationToken);
    }
}
