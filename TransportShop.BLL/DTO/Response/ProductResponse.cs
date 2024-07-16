using TransportShop.DAL.Entities;

namespace TransportShop.BLL.DTO.Response
{
    internal class ProductResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<Product>? Products { get; set; }
    }
}
