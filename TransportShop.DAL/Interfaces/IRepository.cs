using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    public interface IRepository<T> where T : AbstractEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}