using Microsoft.EntityFrameworkCore;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.DAL.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public async Task<Account?> GetAccountByLoginAndPasswordAsync(string login, string password, CancellationToken cancellationToken = default)
        {
            return await db.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Login == login && a.Password == password, cancellationToken);
        }

        public async Task<Account> GetAccountByUserAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await db.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == userId, cancellationToken);
        }
    }
}
