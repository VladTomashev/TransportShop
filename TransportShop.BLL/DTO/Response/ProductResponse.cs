using TransportShop.DAL.Entities;

namespace TransportShop.BLL.DTO.Response
{
    internal class ProductResponse
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }
        public int MaxSpeed { get; set; }
        public double FuelConsumption { get; set; }
    }
}
