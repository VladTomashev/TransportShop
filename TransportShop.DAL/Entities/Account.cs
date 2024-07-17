using TransportShop.DAL.Enums;

namespace TransportShop.DAL.Entities
{
    public class Account : AbstractEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public User? User { get; set; }
        public RefreshToken? RefreshToken { get; set; }
    }
}
