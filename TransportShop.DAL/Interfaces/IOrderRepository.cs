using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    internal interface IOrderRepository : IRepository<Order>
    {
        public List<Order> GetOrdersByUser(int userId);
    }
}
