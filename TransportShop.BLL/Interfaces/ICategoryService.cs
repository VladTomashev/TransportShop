using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    internal interface ICategoryService
    {
        public Task<CategoryResponse> GetProductsByCategory(CategoryRequest category, CancellationToken cancellationToken = default);
        public Task AddNewCategoryAsync(CategoryRequest category, CancellationToken cancellationToken =default);
        public Task DeleteCategoryAsync(CategoryRequest category, CancellationToken cancellationToken = default);
        public Task<List<Category>> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken = default);
    }
}
