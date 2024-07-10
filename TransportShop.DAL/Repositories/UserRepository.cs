using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.DAL.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public User? GetUserByOrder(int orderId)
        {
            foreach (var user in db.Users)
            {
                if (user.Orders.Where(order => order.Id == orderId).ToList().Count != 0)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
