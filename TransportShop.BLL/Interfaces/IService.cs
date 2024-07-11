using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    internal interface IService<T> where T : AbstractEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
