using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    internal interface IOrderRepository : IRepository<Order>
    {
        public Task<List<Order>> GetOrdersByUserAsync(int userId);
    }
}
