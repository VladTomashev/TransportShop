using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TransportShop.DAL.Entities;

namespace TransportShop.DAL.EF.EntitiesConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.IdUser)
                .HasPrincipalKey(u => u.Id);

            builder.Navigation(o => o.User).AutoInclude();
            builder.Navigation(o => o.OrderItems).AutoInclude();
        }
    }
}
