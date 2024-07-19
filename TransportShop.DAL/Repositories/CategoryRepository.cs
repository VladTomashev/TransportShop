using Microsoft.EntityFrameworkCore;
using System.Threading;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.DAL.Repositories
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        public Task<List<Category>> GetCategoryByNameAsync(string name, CancellationToken cancellationToken = default)
        {
               return db.Categories.Where(category => category.Name == name).ToListAsync(cancellationToken);
        }
    }
}
