using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    internal interface ICategoryRepository : IRepository<Category>
    {
        public Task<Category?> GetCategoryByNameAsync(string name);
    }
}
