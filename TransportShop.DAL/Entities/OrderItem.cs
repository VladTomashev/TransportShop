namespace TransportShop.DAL.Entities
{
    public class OrderItem : AbstractEntity
    {
        public int IdProduct { get; set; }
        public int IdOrders { get; set; }
        public int Count { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
