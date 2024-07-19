using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    internal interface IProductService
    {
        public Task Add(ProductRequest product, CancellationToken cancellationToken = default);
        public Task Delete(ProductRequest product, CancellationToken cancellationToken = default);
        public Task Update(int id, ProductRequest product, CancellationToken cancellationToken = default);
        public Task<ProductResponse> GetByID(int productID, CancellationToken cancellationToken = default);
        public Task<ProductResponse> GetByName(string name, CancellationToken cancellationToken = default);
    }
}
