using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    internal interface IOrderItemsService : IService <OrderItem>
    {
        public Task <List<OrderItem>> GetOrderItemsAsync (int orderId);
    }
}
