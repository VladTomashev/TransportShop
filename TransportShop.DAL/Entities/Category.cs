namespace TransportShop.DAL.Entities
{
    public class Category : AbstractEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}
