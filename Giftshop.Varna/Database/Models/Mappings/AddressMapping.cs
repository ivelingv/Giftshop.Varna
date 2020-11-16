using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftshop.Varna.Database.Models.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("user_addresses", "dbo")
                .HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.Id)
             .ValueGeneratedOnAdd()
             .IsRequired();

            builder.Property(e => e.CreateDate)
                .HasColumnName("create_date")
                .IsRequired();

            builder.Property(e => e.UpdateDate)
               .HasColumnName("update_date")
               .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(e => e.Addresses)
                .HasForeignKey(e => e.UserId);

            builder.Property(e => e.UserId)
               .HasColumnName("user_id")
               .IsRequired();

            builder.Property(e => e.Country)
                .HasColumnName("country")
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(e => e.City)
                .HasColumnName("city")
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.PostalCode)
                .HasColumnName("postal_code")
                .HasMaxLength(30);

            builder.Property(e => e.AddressLine1)
                .HasColumnName("address_line_1")
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.AddressLine2)
                .HasColumnName("address_line_2")
               .HasMaxLength(128);

            builder.Property(e => e.AddressLine3)
                .HasColumnName("address_line_3")
                .HasMaxLength(128);

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
