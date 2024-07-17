using System.Security.Claims;
using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;

namespace TransportShop.BLL.Interfaces
{
    public interface ITokenService
    { 
        public Task<string> GenerateAccessToken(IEnumerable<Claim> claims);
        public Task<string> GenerateRefreshToken();
        public Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
        public Task<TokenResponse> RefreshToken(TokenRequest request);

    }
}
