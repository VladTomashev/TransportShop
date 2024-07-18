using System.Security.Claims;

namespace TransportShop.BLL.Interfaces
{
    public interface ITokenService
    { 
        public string GenerateAccessToken(IEnumerable<Claim> claims);
        public string GenerateRefreshToken();
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

    }
}
