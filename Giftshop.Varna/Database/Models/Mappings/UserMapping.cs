using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Giftshop.Varna.Database.Models.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", "dbo")
                .HasKey(e => e.Id)
                .HasName("id");

            builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder.Property(e => e.CreateDate)
                .HasColumnName("create_date")
                .IsRequired();

            builder.Property(e => e.UpdateDate)
               .HasColumnName("update_date")
               .IsRequired();

            builder.HasMany(e => e.Addresses)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            builder.HasMany(e => e.Carts)
               .WithOne(e => e.User)
               .HasForeignKey(e => e.UserId);

            builder.HasIndex(e => e.Username)
                .IsUnique();

            builder.Property(e => e.Username)
                .HasColumnName("username")
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .IsRequired()
                .HasDefaultValue(UserStatus.Active);

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .IsRequired()
                .HasDefaultValue(UserType.Client);

            builder.HasData(new User
            {
                Id = 1,
                Addresses = null,
                Carts = null,
                CreateDate = DateTime.Now,
                Name = "Administrator",
                Status = UserStatus.Active,
                Type = UserType.Administrator,
                UpdateDate = DateTime.Now,
                Username = "administrator@giftshop.eu",
                Password = "02989d0805b74512a49a818915c67070"
            }) ;
        }
    }
}
