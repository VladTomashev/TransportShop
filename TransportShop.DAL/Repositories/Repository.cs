using TransportShop.DAL.EF;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : AbstractEntity
    {
        protected DataContext db;
        public Repository()
        {
            db = new DataContext();
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = db.Set<T>().Find(id);

            if (entity != null)
            {
                db.Set<T>().Remove(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            db.Set<T>().Update(entity);
            db.SaveChanges();
        }
    }
}
