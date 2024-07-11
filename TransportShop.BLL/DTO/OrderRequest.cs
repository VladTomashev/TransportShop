using TransportShop.DAL.Entities;

namespace TransportShop.BLL.DTO
{
    internal class OrderRequest
    {
        public string UserName { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
