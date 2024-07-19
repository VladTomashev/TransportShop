using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Task<List<Category>> GetCategoryByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}
