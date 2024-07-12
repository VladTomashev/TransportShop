using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    internal interface IUserService : IService<User>
    {
        public Task<User> GetUserByOrderAsync(int orderId);
    }
}
