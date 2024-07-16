using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    internal interface ICategoryService : IService<Category>
    {
        public Task<Product> GetProductsByCategory(int categoryId);
    }
}
