namespace TransportShop.DAL.Entities
{
    public class Product : AbstractEntity
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }
        public int MaxSpeed { get; set; }
        public double FuelConsumption { get; set; }

        public Category Category { get; set; }
    }
}
