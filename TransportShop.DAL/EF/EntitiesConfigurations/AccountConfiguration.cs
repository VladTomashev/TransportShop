using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Enums;

namespace TransportShop.DAL.EF.EntitiesConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasOne(a => a.User)
                .WithOne(u => u.Account)
                .HasForeignKey<User>(u => u.Id);

            builder.Property(a => a.Role)
                .HasConversion<int>();

        }
    }
}
