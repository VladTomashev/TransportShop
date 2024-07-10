using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TransportShop.DAL.Entities;

namespace TransportShop.DAL.EF.EntitiesConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.IdProduct)
                .HasPrincipalKey(p => p.Id);

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.IdOrders)
                .HasPrincipalKey(o => o.Id);

            builder.Navigation(oi => oi.Product).AutoInclude();
            builder.Navigation(oi => oi.Order).AutoInclude();
        }
    }
}
