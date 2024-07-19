using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<List<Product>> GetProductByCategoryAsync(string categoryName, CancellationToken cancellationToken = default);
        public Task<List<Product>> GetProductsByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}
