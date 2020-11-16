using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giftshop.Varna.Database.Models.Mappings
{
    public class ShoppingCartProductMapping : IEntityTypeConfiguration<ShoppingCartProduct>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartProduct> builder)
        {
            builder.ToTable("shopping_cart_products", "dbo")
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

            builder.HasOne(e => e.ShoppingCart)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.ShoppingCartId);

            builder.HasOne(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId);

            builder.Property(e => e.Currency)
                .HasColumnName("currency")
                .HasMaxLength(1024);

            builder.Property(e => e.Price)
                .HasColumnName("price")
                .IsRequired();

            builder.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .IsRequired();
        }
    }
}
