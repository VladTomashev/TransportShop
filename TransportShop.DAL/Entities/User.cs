namespace TransportShopAPI.Entities
{
    public class User : AbstractEntity
    {
        public string login { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        public List<Order> orders { get; set; }
    }
}
