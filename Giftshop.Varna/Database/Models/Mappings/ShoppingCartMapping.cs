using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giftshop.Varna.Database.Models.Mappings
{
    public class ShoppingCartMapping : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("shopping_cart", "dbo")
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

            builder.HasMany(e => e.Products)
                .WithOne(e => e.ShoppingCart)
                .HasForeignKey(e => e.ShoppingCartId);

            builder.HasOne(e => e.User)
                .WithMany(e => e.Carts)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.DeliveryAddress)
                .WithMany()
                .HasForeignKey(e => e.DeliveryAddressId);

            builder.Property(e => e.Comment)
                .HasColumnName("comment")
                .HasMaxLength(1024);

            builder.Property(e => e.PaymentMethod)
                .HasColumnName("payment_method")
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasDefaultValue(ShoppingCartStatus.None)
                .IsRequired();

            builder.Property(e => e.Currency)
                .HasColumnName("currency")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(e => e.TotalPrice)
              .HasColumnName("total_price")
              .IsRequired();
        }
    }
}
