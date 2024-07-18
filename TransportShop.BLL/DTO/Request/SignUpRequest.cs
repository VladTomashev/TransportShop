namespace TransportShop.BLL.DTO.Request
{
    public class SignUpRequest
    {
        public required string Login { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
    }
}
