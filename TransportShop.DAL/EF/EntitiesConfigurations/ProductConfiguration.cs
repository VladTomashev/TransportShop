using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TransportShop.DAL.Entities;

namespace TransportShop.DAL.EF.EntitiesConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.IdCategory)
                .HasPrincipalKey(c => c.Id);

            builder.Navigation(p => p.Category).AutoInclude();
        }
    }
}
