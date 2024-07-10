using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await db.Set<T>().FindAsync(id);

            if (entity != null)
            {
                db.Set<T>().Remove(entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            db.Set<T>().Update(entity);
            await db.SaveChangesAsync();
        }
    }
}
