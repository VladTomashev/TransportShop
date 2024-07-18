using Microsoft.EntityFrameworkCore;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public async Task<User?> GetUserByAccountAsync(int accId, CancellationToken cancellationToken = default)
        {
            return await db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == accId, cancellationToken);
        }
    }
}
 