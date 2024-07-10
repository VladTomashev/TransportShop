using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    internal interface IRepository<T> where T : AbstractEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
