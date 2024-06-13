using Microsoft.AspNetCore.Identity;

namespace DemandForcast.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
