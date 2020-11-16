using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Giftshop.Varna.Migrations
{
    public partial class UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: false),
                    username = table.Column<string>(maxLength: 128, nullable: false),
                    name = table.Column<string>(maxLength: 512, nullable: false),
                    password = table.Column<string>(maxLength: 128, nullable: false),
                    status = table.Column<int>(nullable: false, defaultValue: 1),
                    type = table.Column<int>(nullable: false, defaultValue: 2)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    description = table.Column<string>(maxLength: 1024, nullable: false),
                    title = table.Column<string>(maxLength: 128, nullable: false),
                    is_active = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_category_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_addresses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: false),
                    user_id = table.Column<long>(nullable: false),
                    country = table.Column<string>(maxLength: 3, nullable: false),
                    city = table.Column<string>(maxLength: 128, nullable: false),
                    postal_code = table.Column<string>(maxLength: 30, nullable: true),
                    address_line_1 = table.Column<string>(maxLength: 128, nullable: false),
                    address_line_2 = table.Column<string>(maxLength: 128, nullable: true),
                    address_line_3 = table.Column<string>(maxLength: 128, nullable: true),
                    is_active = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_addresses_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    currency = table.Column<string>(maxLength: 3, nullable: false),
                    description = table.Column<string>(maxLength: 1024, nullable: false),
                    title = table.Column<string>(maxLength: 128, nullable: false),
                    image_guid = table.Column<string>(nullable: true),
                    view_count = table.Column<int>(nullable: false),
                    rating = table.Column<int>(nullable: false),
                    is_active = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shopping_cart",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: false),
                    total_price = table.Column<double>(nullable: false),
                    currency = table.Column<string>(maxLength: 3, nullable: false),
                    comment = table.Column<string>(maxLength: 1024, nullable: true),
                    payment_method = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false, defaultValue: 0),
                    UserId = table.Column<long>(nullable: false),
                    DeliveryAddressId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shopping_cart_user_addresses_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalSchema: "dbo",
                        principalTable: "user_addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shopping_cart_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shopping_cart_products",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    ShoppingCartId = table.Column<long>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    currency = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shopping_cart_products_products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shopping_cart_products_shopping_cart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalSchema: "dbo",
                        principalTable: "shopping_cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "users",
                columns: new[] { "Id", "create_date", "name", "password", "status", "type", "update_date", "username" },
                values: new object[] { 1L, new DateTime(2020, 10, 31, 14, 12, 19, 208, DateTimeKind.Local).AddTicks(8338), "Administrator", "02989d0805b74512a49a818915c67070", 1, 1, new DateTime(2020, 10, 31, 14, 12, 19, 228, DateTimeKind.Local).AddTicks(1260), "administrator@giftshop.eu" });

            migrationBuilder.CreateIndex(
                name: "IX_category_title",
                schema: "dbo",
                table: "category",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_category_UserId",
                schema: "dbo",
                table: "category",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                schema: "dbo",
                table: "products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_title",
                schema: "dbo",
                table: "products",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_UserId",
                schema: "dbo",
                table: "products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_shopping_cart_DeliveryAddressId",
                schema: "dbo",
                table: "shopping_cart",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_shopping_cart_UserId",
                schema: "dbo",
                table: "shopping_cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_shopping_cart_products_ProductId",
                schema: "dbo",
                table: "shopping_cart_products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_shopping_cart_products_ShoppingCartId",
                schema: "dbo",
                table: "shopping_cart_products",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_user_addresses_user_id",
                schema: "dbo",
                table: "user_addresses",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                schema: "dbo",
                table: "users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shopping_cart_products",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "products",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "shopping_cart",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "category",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "user_addresses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "users",
                schema: "dbo");
        }
    }
}
