using TransportShop.BLL.DTO.Request;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserByOrderAsync(int orderId, CancellationToken cancellationToken = default);
        public Task SignInAsync(SignInRequest request, CancellationToken cancellationToken = default);
        public Task SignUpAsync(SignUpRequest request, CancellationToken cancellationToken = default);
    }
}
