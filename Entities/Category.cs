namespace TransportShopAPI.Entities
{
    public class Category : AbstractEntity
    {
        public string name { get; set; }

        public List<Product> products { get; set; }
    }
}
