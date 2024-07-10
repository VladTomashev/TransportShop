namespace TransportShop.DAL.Entities
{
    public class User : AbstractEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public List<Order> Orders { get; set; }
    }
}
