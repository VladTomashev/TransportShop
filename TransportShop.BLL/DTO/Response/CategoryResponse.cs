using TransportShop.DAL.Entities;

namespace TransportShop.BLL.DTO.Response
{
    internal class CategoryResponse
    {
        public List<Product> ProductsInCategory { get; set; }
        public string CategoryName { get; set; }
    }
}
