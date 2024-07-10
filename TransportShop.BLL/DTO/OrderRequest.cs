using TransportShop.DAL.Entities;

namespace TransportShop.BLL.DTO
{
    internal class OrderRequest
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
