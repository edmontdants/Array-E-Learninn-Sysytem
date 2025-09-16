using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Domain.Interfaces.Repositories;
using ArrayELearnApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ArrayELearnApi.Infrastructure.Repositories
{
    public class RefreshTokenRepository(ApplicationDbContext context) : Repository<RefreshToken>(context), IRefreshTokenRepository
    {
        public async Task<IEnumerable<RefreshToken>> GetExpiredTokensAsync(CancellationToken cancellationToken = default) =>
            await _dbSet.Where(t => t.Expires < DateTime.Now).ToListAsync(cancellationToken);

        public async Task RevokeAsync(string token, CancellationToken cancellationToken = default)
        {
            var existing = await GetByTokenAsync(token, cancellationToken);
            if (existing != null)
            {
                existing.IsRevoked = true;
            }
        }

        public async Task<RefreshToken> GetByTokenAsync(string token, CancellationToken cancellationToken = default) =>
            await _dbSet.FirstOrDefaultAsync(t => t.Token == token, cancellationToken);
    }
}
