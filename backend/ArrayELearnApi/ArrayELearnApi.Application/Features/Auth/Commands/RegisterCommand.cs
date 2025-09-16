using ArrayELearnApi.Application.DTOs.Auth;
using MediatR;

namespace ArrayELearnApi.Application.Features.Auth.Commands
{
    public class RegisterCommand : RegisterDto, IRequest<AuthResponse> 
    {
        
    }
}
