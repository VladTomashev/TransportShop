using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    internal interface IUserService : IService<User>
    {
        public User GetUserByOrder(int orderId);
    }
}
