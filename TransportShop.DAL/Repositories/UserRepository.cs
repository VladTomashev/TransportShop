using Microsoft.EntityFrameworkCore;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.DAL.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public async Task<User?> GetUserByOrderAsync(int orderId)
        {
            return await db.Users
                               .Include(user => user.Orders)
                               .FirstOrDefaultAsync(user => user.Orders.Any(order => order.Id == orderId));
        }
    }
}
