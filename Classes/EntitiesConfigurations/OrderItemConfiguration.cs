using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TransportShopAPI.Entities;

namespace TransportShopAPI.Classes.EntitiesConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(oi => oi.product)
                .WithMany()
                .HasForeignKey(oi => oi.idProduct)
                .HasPrincipalKey(p => p.id);

            builder.HasOne(oi => oi.order)
                .WithMany(o => o.orderItems)
                .HasForeignKey(oi => oi.idOrders)
                .HasPrincipalKey(o => o.id);

            builder.Navigation(oi => oi.product).AutoInclude();
            builder.Navigation(oi => oi.order).AutoInclude();
        }
    }
}
