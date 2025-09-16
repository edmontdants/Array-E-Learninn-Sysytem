using System.Security.Claims;

namespace ArrayELearnApi.Application.Interfaces.Auth
{
    public interface IUserClaimsResolverService
    {
        Task<IList<Claim>> GetUserClaimsAsync(string userId);
    }
}
