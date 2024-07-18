using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<List<Product>> GetProductByCategoryAsync(string categoryName);
        public Task<List<Product>> GetProductsByNameAsync(string name);
    }
}
