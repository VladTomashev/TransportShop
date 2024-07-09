namespace TransportShop.DAL.Entities
{
    public class OrderItem : AbstractEntity
    {
        public int idProduct { get; set; }
        public int idOrders { get; set; }
        public int count { get; set; }

        public Product product { get; set; }
        public Order order { get; set; }
    }
}
