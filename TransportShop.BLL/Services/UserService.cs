using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.Interfaces;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Services
{
    public class UserService : IUserService
    {



        public Task SignInAsync(SignInRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task SignUpAsync(SignUpRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
