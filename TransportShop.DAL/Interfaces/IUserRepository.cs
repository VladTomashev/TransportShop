using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User?> GetUserByOrderAsync(int orderId);
    }
}
