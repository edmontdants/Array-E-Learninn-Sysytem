using ArrayELearnApi.Application.DTOs;
using MediatR;

namespace ArrayELearnApi.Application.Features.Auth.Commands
{
    public class RevokeRefreshTokenCommand : IRequest<bool>
    {
        public string RefreshToken { get; set; }
    }
}
