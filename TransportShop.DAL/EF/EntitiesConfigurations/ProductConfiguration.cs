using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TransportShop.DAL.Entities;

namespace TransportShop.DAL.EF.EntitiesConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.category)
                .WithMany(c => c.products)
                .HasForeignKey(p => p.idCategory)
                .HasPrincipalKey(c => c.id);

            builder.Navigation(p => p.category).AutoInclude();
        }
    }
}
