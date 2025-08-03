using ArrayELearnApi.Application.DTOs;
using MediatR;

namespace ArrayELearnApi.Application.Commands
{
    public class RevokeRefreshTokenCommand : IRequest<bool>
    {
        public string RefreshToken { get; set; }
    }
}
