using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Database.Models.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Giftshop.Varna.Database.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext([NotNull] DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAddress> Addresses { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new ShoppingCartMapping());
            modelBuilder.ApplyConfiguration(new ShoppingCartProductMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
