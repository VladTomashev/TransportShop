namespace TransportShop.BLL.DTO.Request
{
    internal class ProductRequest
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }
        public int MaxSpeed { get; set; }
        public double FuelConsumption { get; set; }
    }
}
