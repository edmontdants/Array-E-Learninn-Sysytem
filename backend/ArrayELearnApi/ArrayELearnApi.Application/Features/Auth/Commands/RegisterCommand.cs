using MediatR;

namespace ArrayELearnApi.Application.Features.Auth.Commands
{
    public class RegisterCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
