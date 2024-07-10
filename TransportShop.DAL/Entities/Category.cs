namespace TransportShop.DAL.Entities
{
    public class Category : AbstractEntity
    {
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
