namespace TransportShop.DAL.Entities
{
    public class Order : AbstractEntity
    {
        public int IdUser { get; set; }
        public double TotalPrice { get; set; }

        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
