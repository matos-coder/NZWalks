using Microsoft.AspNetCore.Identity;

namespace test.api.Repositories
{
    public interface ITokenRepository
    {
        string createJwtToken(IdentityUser user, List<string> roles);
    }
}
