using ArrayELearnApi.Application.DTOs;
using MediatR;

namespace ArrayELearnApi.Application.Commands
{
    public class LoginCommand : IRequest<LoginResultDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
