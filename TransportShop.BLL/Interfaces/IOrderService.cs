using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;

namespace TransportShop.DAL.Interfaces
{
    public interface IOrderService
    {
        public Task<List<OrderResponse>> GetOrdersByUserAsync(OrderRequest request, CancellationToken cancellationToken = default);
        public Task CreateOrderAsync(OrderRequest request, CancellationToken cancellationToken = default);
        public Task<OrderResponse> GetOrderByIdAsync(int orderId, CancellationToken cancellationToken = default);
        public Task DeleteOrderById(int orderId, CancellationToken cancellationToken = default);
    }
}