namespace TransportShop.BLL.DTO.Request
{
    internal class OrderItemsRequest
    {
        public int OrderId { get; set; }
        public int ProductId {  get; set; }
        public int ProductCount {  get; set; }
    }
}
