using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<List<Product>> GetProductByCategoryAsync(int categoryId);
        public Task<List<Product>> GetProductsByNameAsync(string name);
    }
}
