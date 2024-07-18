using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        public Task<Account> GetAccountByUserAsync(int userId, CancellationToken cancellationToken = default);
        public Task<Account?> GetAccountByLoginAsync(string login, CancellationToken cancellationToken = default);
    }
}
