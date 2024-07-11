using TransportShop.BLL.Interfaces;
using TransportShop.DAL.Entities;


namespace TransportShop.DAL.Interfaces
{
    internal interface IOrderService : IService<Order>
    {
        public List<Order> GetOrdersByUser(int userId);
    }
}