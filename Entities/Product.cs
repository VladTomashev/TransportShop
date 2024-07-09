namespace TransportShopAPI.Entities
{
    public class Product : AbstractEntity
    {
        public int idCategory { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int weight { get; set; }
        public int maxSpeed { get; set; }
        public double fuelConsumption { get; set; }

        public Category category { get; set; }
    }
}
