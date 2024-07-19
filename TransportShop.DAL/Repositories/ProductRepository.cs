using Microsoft.EntityFrameworkCore;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.DAL.Repositories
{
    internal class ProductRepository : Repository<Product>, IProductRepository 
    {

        public Task<List<Product>> GetProductByCategoryAsync(string categoryName, CancellationToken cancellationToken = default)
        {
            return db.Products.Where(product => product.Name == categoryName).ToListAsync();
        }

        public Task<List<Product>> GetProductsByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return db.Products.Where(product => product.Name.Contains(name)).ToListAsync();
        }
    }
}
