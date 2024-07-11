using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    internal interface IService<T> where T : AbstractEntity
    {
        IEnumerable<T> GetAllAsync();
        T GetByIdAsync(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
