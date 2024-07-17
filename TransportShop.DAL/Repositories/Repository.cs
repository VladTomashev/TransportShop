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

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await db.Set<T>().AddAsync(entity, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            T entity = await db.Set<T>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
            db.Set<T>().Remove(entity);
            await db.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await db.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await db.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            db.Set<T>().Update(entity);
            await db.SaveChangesAsync(cancellationToken);
        }
    }
}
