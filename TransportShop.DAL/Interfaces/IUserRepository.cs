using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    internal interface IUserRepository : IRepository<User>
    {
        public User? GetUserByOrder(int orderId);
    }
}
