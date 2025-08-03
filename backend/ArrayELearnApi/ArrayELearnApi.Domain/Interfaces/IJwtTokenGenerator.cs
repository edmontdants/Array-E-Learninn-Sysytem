using ArrayELearnApi.Domain.Entities;

namespace ArrayELearnApi.Domain.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateJwtToken(ApplicationUser user, IList<string> roles);
    }
}
