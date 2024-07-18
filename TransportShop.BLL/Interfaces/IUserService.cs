using System.Security.Claims;
using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    public interface IUserService
    {
        public Task<TokenResponse> SignInAsync(SignInRequest request, CancellationToken cancellationToken = default);
        public Task<TokenResponse> SignUpAsync(SignUpRequest request, CancellationToken cancellationToken = default);
        public Task<TokenResponse> RefreshTokenAsync(TokenRequest request, CancellationToken cancellationToken = default);
        public Task<int> GetMyIdByJwtAsync(ClaimsPrincipal principal, CancellationToken cancellationToken = default);
        public Task<UserProfileResponse> GetMyProfileByJwtAsync(ClaimsPrincipal principal, CancellationToken cancellationToken = default);
        public Task<IEnumerable<UserResponse>> GetAllUsersAsync(CancellationToken cancellationToken = default);
        public Task<UserResponse> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task DeleteUserAsync(int id, CancellationToken cancellationToken = default);

    }
}
