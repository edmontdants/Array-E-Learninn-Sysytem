using ArrayELearnApi.Domain.Entities;

namespace ArrayELearnApi.Domain.Interfaces
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken>
    {
        Task<IEnumerable<RefreshToken>> GetExpiredTokensAsync();
        Task RevokeAsync(string token);
        Task<RefreshToken> GetByTokenAsync(string token);
    }
}
