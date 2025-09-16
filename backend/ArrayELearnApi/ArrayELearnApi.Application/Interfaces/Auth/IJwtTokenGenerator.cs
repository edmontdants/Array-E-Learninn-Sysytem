using ArrayELearnApi.Domain.Entities.Auth;
using Microsoft.IdentityModel.Tokens;

namespace ArrayELearnApi.Application.Interfaces.Auth
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateJwtTokenAsync(ApplicationUser user);
    }
}
