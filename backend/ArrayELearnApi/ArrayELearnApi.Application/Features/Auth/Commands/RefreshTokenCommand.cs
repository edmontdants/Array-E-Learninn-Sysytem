using ArrayELearnApi.Application.DTOs.Auth;
using MediatR;

namespace ArrayELearnApi.Application.Features.Auth.Commands
{
    public class RefreshTokenCommand : IRequest<LoginResultDto>
    {
        public string RefreshToken { get; set; }
    }

}
