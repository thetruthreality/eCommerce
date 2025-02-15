using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedproductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 15, 5, 57, 52, 819, DateTimeKind.Utc).AddTicks(8300), "Latest Apple iPhone", "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone-15-finish-select-202309-6-1inch_AV1?wid=940&hei=1112&fmt=jpeg&qlt=90&.v=1692912410763", "iPhone 15", 999.99m, 50 },
                    { 2, new DateTime(2025, 2, 15, 5, 57, 52, 819, DateTimeKind.Utc).AddTicks(8310), "Flagship Samsung phone", "https://images.samsung.com/is/image/samsung/p6pim/in/sm-s911bzeains/gallery/in-galaxy-s23-s911-446678-sm-s911bzeains-thumb-534613627?$172_172_PNG$", "Samsung Galaxy S23", 899.99m, 40 },
                    { 3, new DateTime(2025, 2, 15, 5, 57, 52, 819, DateTimeKind.Utc).AddTicks(8310), "Apple MacBook Pro 16-inch", "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mbp16-spacegray-select-202301?wid=800&hei=800&fmt=jpeg&qlt=90&.v=1671304673229", "MacBook Pro", 2499.99m, 30 },
                    { 4, new DateTime(2025, 2, 15, 5, 57, 52, 819, DateTimeKind.Utc).AddTicks(8310), "Powerful Windows laptop", "https://i.dell.com/sites/csimages/App-Merchandizing_Images/all/xps-15-9520-laptop-btp-app.png", "Dell XPS 15", 1999.99m, 20 },
                    { 5, new DateTime(2025, 2, 15, 5, 57, 52, 819, DateTimeKind.Utc).AddTicks(8310), "Noise-canceling headphones", "https://m.media-amazon.com/images/I/61D4Z3yKPAL._AC_UF1000,1000_QL80_.jpg", "Sony WH-1000XM5", 349.99m, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
