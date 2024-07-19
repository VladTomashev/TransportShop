using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;
using TransportShop.DAL.Entities;


namespace TransportShop.BLL.Interfaces
{
    internal interface IOrderItemsService
    {
        public Task AddOrderItem(OrderItemsRequest order, CancellationToken cancellationToken = default);
        public Task DeleteOrderItem(int id, CancellationToken cancellationToken = default);
        public Task <List<OrderItemsResponse>> GetOrderItemsAsync (OrderItemsRequest order, CancellationToken cancellationToken = default);
    }
}
