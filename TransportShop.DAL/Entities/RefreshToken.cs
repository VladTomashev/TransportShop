namespace TransportShop.DAL.Entities
{
    public class RefreshToken : AbstractEntity
    {
        public string? Token { get; set; }
        public DateTime? LifeTime { get; set; }

        public Account? Account { get; set; }
    }
}
