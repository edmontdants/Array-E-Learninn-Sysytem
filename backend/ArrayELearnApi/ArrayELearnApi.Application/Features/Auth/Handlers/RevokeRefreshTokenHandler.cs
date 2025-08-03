using ArrayELearnApi.Application.Commands;
using ArrayELearnApi.Domain.Interfaces;
using MediatR;

namespace ArrayELearnApi.Application.Handlers
{
    public class RevokeRefreshTokenRequestHandler : IRequestHandler<RevokeRefreshTokenCommand, bool>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepo;

        public RevokeRefreshTokenRequestHandler(IRefreshTokenRepository refreshTokenRepo) => _refreshTokenRepo = refreshTokenRepo;

        public async Task<bool> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            await _refreshTokenRepo.RevokeAsync(request.RefreshToken);
            await _refreshTokenRepo.SaveChangesAsync();
            return true;
        }
    }
}
