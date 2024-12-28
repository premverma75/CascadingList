using System.Security.Claims;

namespace CascadingList.Repositories.IRepository
{
    public interface ITokenService
    {
            string GenerateAccessToken(string username);
            string GenerateRefreshToken();
            ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
