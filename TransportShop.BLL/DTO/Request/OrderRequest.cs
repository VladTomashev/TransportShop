using System.Security.Claims;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.DTO.Request
{
    internal class OrderRequest
    {
        public ClaimsPrincipal Principal { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
