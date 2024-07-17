using TransportShop.BLL.DTO.Request;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    public interface IUserService
    {
        public Task SignInAsync(SignInRequest request, CancellationToken cancellationToken = default);
        public Task SignUpAsync(SignUpRequest request, CancellationToken cancellationToken = default);
        public Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);
        public Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task DeleteUserAsync(int id, CancellationToken cancellationToken = default);

    }
}
