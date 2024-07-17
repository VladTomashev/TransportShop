using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportShop.DAL.Entities;

namespace TransportShop.DAL.EF.EntitiesConfigurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasOne(rt => rt.Account)
                .WithOne(a => a.RefreshToken)
                .HasForeignKey<RefreshToken>(rt => rt.Id);

        }
    }
}
