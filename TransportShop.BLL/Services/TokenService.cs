using System.Security.Claims;
using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;
using TransportShop.BLL.Interfaces;

namespace TransportShop.BLL.Services
{
    public class TokenService : ITokenService
    {
        public Task<string> GenerateAccessToken(IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token)
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponse> RefreshToken(TokenRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
