using ArrayELearnApi.Domain.Entities;
using ArrayELearnApi.Domain.Interfaces;
using ArrayELearnApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArrayELearnApi.Infrastructure.Repositories
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<RefreshToken>> GetExpiredTokensAsync() =>
            await _dbSet.Where(t => t.Expires < DateTime.UtcNow).ToListAsync();

        public async Task RevokeAsync(string token)
        {
            var existing = await GetByTokenAsync(token);
            if (existing != null)
            {
                existing.IsRevoked = true;
            }
        }

        public async Task<RefreshToken> GetByTokenAsync(string token) =>
            await _dbSet.FirstOrDefaultAsync(t => t.Token == token);

    }
}
