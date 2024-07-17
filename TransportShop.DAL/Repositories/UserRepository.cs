using Microsoft.EntityFrameworkCore;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public async Task<User?> GetUserByOrderAsync(int orderId, CancellationToken cancellationToken = default)
        {
            return await db.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Orders.Any(order => order.Id == orderId), cancellationToken);
        }
    }
}
