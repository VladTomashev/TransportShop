using System.Security.Claims;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.DTO.Request
{
    public class OrderRequest
    {
        public ClaimsPrincipal Principal { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
