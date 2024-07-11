using System.Collections.Generic;
using System.Threading.Tasks;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    internal interface IService<T> where T : AbstractEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
