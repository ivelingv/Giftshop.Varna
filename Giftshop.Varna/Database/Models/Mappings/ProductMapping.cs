using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giftshop.Varna.Database.Models.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products", "dbo")
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

            builder.HasOne(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            builder.HasIndex(e => e.Title)
                .IsUnique();

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired()
                .HasMaxLength(1024);

            builder.Property(e => e.Price)
                .HasColumnName("price")
                .IsRequired();

            builder.Property(e => e.Currency)
               .HasColumnName("currency")
               .IsRequired()
               .HasMaxLength(3);

            builder.Property(e => e.IsActive)
               .HasColumnName("is_active")
               .IsRequired()
               .HasDefaultValue(true);

            builder.Property(e => e.Image)
               .HasColumnName("image_guid");

            builder.Property(e => e.Rating)
               .HasColumnName("rating");

            builder.Property(e => e.ViewCount)
              .HasColumnName("view_count");
        }
    }
}
