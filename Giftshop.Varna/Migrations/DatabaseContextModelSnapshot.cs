﻿// <auto-generated />
using System;
using Giftshop.Varna.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Giftshop.Varna.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("Giftshop.Varna.Database.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1024);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("is_active")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("update_date")
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id")
                        .HasName("id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("category","dbo");
                });

            modelBuilder.Entity("Giftshop.Varna.Database.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnName("currency")
                        .HasColumnType("TEXT")
                        .HasMaxLength(3);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1024);

                    b.Property<string>("Image")
                        .HasColumnName("image_guid")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("is_active")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnName("price")
                        .HasColumnType("REAL");

                    b.Property<int>("Rating")
                        .HasColumnName("rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("update_date")
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ViewCount")
                        .HasColumnName("view_count")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id")
                        .HasName("id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("products","dbo");
                });

            modelBuilder.Entity("Giftshop.Varna.Database.Models.ShoppingCart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnName("comment")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1024);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnName("currency")
                        .HasColumnType("TEXT")
                        .HasMaxLength(3);

                    b.Property<long>("DeliveryAddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentMethod")
                        .HasColumnName("payment_method")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("status")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0);

                    b.Property<double>("TotalPrice")
                        .HasColumnName("total_price")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("update_date")
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id")
                        .HasName("id");

                    b.HasIndex("DeliveryAddressId");

                    b.HasIndex("UserId");

                    b.ToTable("shopping_cart","dbo");
                });

            modelBuilder.Entity("Giftshop.Varna.Database.Models.ShoppingCartProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .HasColumnName("currency")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1024);

                    b.Property<double>("Price")
                        .HasColumnName("price")
                        .HasColumnType("REAL");

                    b.Property<long>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ShoppingCartId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("update_date")
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("shopping_cart_products","dbo");
                });

            modelBuilder.Entity("Giftshop.Varna.Database.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(512);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("status")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1);

                    b.Property<int>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("type")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(2);

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("update_date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.HasKey("Id")
                        .HasName("id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("users","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateDate = new DateTime(2020, 11, 5, 17, 40, 4, 34, DateTimeKind.Local).AddTicks(5402),
                            Name = "Administrator",
                            Password = "02989d0805b74512a49a818915c67070",
                            Status = 1,
                            Type = 1,
                            UpdateDate = new DateTime(2020, 11, 5, 17, 40, 4, 54, DateTimeKind.Local).AddTicks(8156),
                            Username = "administrator@giftshop.eu"
                        });
                });

            modelBuilder.Entity("Giftshop.Varna.Database.Models.UserAddress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnName("address_line_1")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("AddressLine2")
                        .HasColumnName("address_line_2")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("AddressLine3")
                        .HasColumnName("address_line_3")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("country")
                        .HasColumnType("TEXT")
                        .HasMaxLength(3);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("is_active")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<string>("PostalCode")
                        .HasColumnName("postal_code")
                        .HasColumnType("TEXT")
                        .HasMaxLength(30);

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("update_date")
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id")
                        .HasName("id");

                    b.HasIndex("UserId");

                    b.ToTable("user_addresses","dbo");
                });

            modelBuilder.Entity("Giftshop.Varna.Database.Models.Category", b =>
                {
                    b.HasOne("Giftshop.Varna.Database.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Giftshop.Varna.Database.Models.Product", b =>
                {
                    b.HasOne("Giftshop.Varna.Database.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Giftshop.Varna.Database.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Giftshop.Varna.Database.Models.ShoppingCart", b =>
                {
                    b.HasOne("Giftshop.Varna.Database.Models.UserAddress", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Giftshop.Varna.Database.Models.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Giftshop.Varna.Database.Models.ShoppingCartProduct", b =>
                {
                    b.HasOne("Giftshop.Varna.Database.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Giftshop.Varna.Database.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("Products")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Giftshop.Varna.Database.Models.UserAddress", b =>
                {
                    b.HasOne("Giftshop.Varna.Database.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
