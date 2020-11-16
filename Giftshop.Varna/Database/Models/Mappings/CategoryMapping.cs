using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giftshop.Varna.Database.Models.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category", "dbo")
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
                .WithOne(e => e.Category)
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

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true);
        }
    }
}
