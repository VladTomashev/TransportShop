namespace TransportShopAPI.Entities
{
    public class Order : AbstractEntity
    {
        public int idUser { get; set; }
        public double totalPrice { get; set; }

        public User user { get; set; }
        public List<OrderItem> orderItems { get; set; }
    }
}
