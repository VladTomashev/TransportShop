using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    internal interface IService<T> where T : AbstractEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
