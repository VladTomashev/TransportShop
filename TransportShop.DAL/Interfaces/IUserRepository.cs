using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User?> GetUserByAccountAsync(int accId, CancellationToken cancellationToken = default);
    }
}
