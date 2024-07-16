using Microsoft.EntityFrameworkCore;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.DAL.Repositories
{
    internal class ProductRepository : Repository<Product>, IProductRepository 
    {

        public Task<List<Product>> GetProductByCategoryAsync(int categoryId)
        {
            return db.Products.Where(product => product.IdCategory == categoryId).ToListAsync();
        }

        public Task<List<Product>> GetProductsByNameAsync(string name)
        {
            return db.Products.Where(product => product.Name.Contains(name)).ToListAsync();
        }
    }
}
