using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TransportShopAPI.Entities;

namespace TransportShopAPI.Classes.EntitiesConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.user)
                .WithMany(u => u.orders)
                .HasForeignKey(o => o.idUser)
                .HasPrincipalKey(u => u.id);

            builder.Navigation(o => o.user).AutoInclude();
            builder.Navigation(o => o.orderItems).AutoInclude();
        }
    }
}
