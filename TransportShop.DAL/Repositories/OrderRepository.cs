using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.DAL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public List<Order> GetOrdersByUser(int userId)
        {
            return db.Orders.Where(order => order.IdUser == userId).ToList();
        }
    }
}
