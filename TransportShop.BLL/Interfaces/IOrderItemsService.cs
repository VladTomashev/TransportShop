using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    internal interface IOrderItemsService : IService <OrderItem>
    {
        public Task <List<OrderItem>> GetOrderItemsAsync (int orderId);
    }
}
