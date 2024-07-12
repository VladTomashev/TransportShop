using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    internal interface IUserRepository : IRepository<User>
    {
        public Task<User?> GetUserByOrderAsync(int orderId);
    }
}
