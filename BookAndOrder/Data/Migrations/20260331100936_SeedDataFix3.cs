using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookAndOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataFix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Postcode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cfc-9412-4cfe-afbf-59f706d72cf6", 0, null, null, "a65eddf2-2bc0-45e3-b395-669a0dd2147f", "admin@gmail.com", true, "Admin", "User", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEDkVJzWCl2+6TAboe6pak9+ChvU4+5gEIoolR1MpgI22jbf48RpvAkWcM0Aj5pONHA==", null, false, null, "05cf4618-16ba-4a26-aa65-1220a3c05e6c", false, "admin@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { "A deep dive into modern C# features and asynchronous programming patterns.", "https://picsum.photos/id/24/400/400", "Mastering C# 12", 449m, 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 1, "Professionalism, pragmatism, and pride in the art of software development.", "https://picsum.photos/id/1/400/400", "The Clean Coder", 329m, 8 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 1, "Learn how to bridge the gap between object-oriented code and relational databases.", "https://picsum.photos/id/2/400/400", "Entity Framework Core", 399m, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 2, "Noise-canceling over-ear headphones with 40-hour battery life and premium sound.", "https://picsum.photos/id/3/400/400", "Wireless Headphones", 1999m, 25 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 5, 2, "RGB backlit mechanical keyboard with tactile switches for gaming and office work.", "https://picsum.photos/id/4/400/400", "Mechanical Keyboard", 1250m, 12 },
                    { 6, 2, "Fitness tracker with heart rate monitor, GPS, and waterproof design.", "https://picsum.photos/id/5/400/400", "Smart Watch Pro", 2490m, 60 },
                    { 7, 2, "34-inch curved display perfect for multitasking and immersive gaming experiences.", "https://picsum.photos/id/6/400/400", "Ultrawide Monitor", 5495m, 0 },
                    { 8, 3, "Warm, comfortable hoodie made from 100% organic cotton. Perfect for winter.", "https://picsum.photos/id/7/400/400", "Hoodie Grey Edition", 599m, 40 },
                    { 9, 3, "Classic blue denim jacket with a modern fit and high-quality stitching.", "https://picsum.photos/id/8/400/400", "Denim Jacket", 899m, 10 },
                    { 10, 3, "Durable and stylish leather boots for all-weather exploration.", "https://picsum.photos/id/9/400/400", "Leather Boots", 1495m, 4 },
                    { 11, 4, "Automatic espresso machine with built-in grinder for the perfect morning coffee.", "https://picsum.photos/id/10/400/400", "Espresso Machine", 4200m, 7 },
                    { 12, 4, "Healthy cooking with 90% less oil. Large capacity for family dinners.", "https://picsum.photos/id/11/400/400", "Air Fryer XL", 1290m, 22 },
                    { 13, 4, "Professional 5-piece stainless steel knife set with ergonomic wooden handles.", "https://picsum.photos/id/12/400/400", "Chef's Knife Set", 850m, 15 },
                    { 14, 4, "Heavy-duty skillet for perfect searing and even heat distribution.", "https://picsum.photos/id/13/400/400", "Cast Iron Skillet", 450m, 30 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "02174cfc-9412-4cfe-afbf-59f706d72cf6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "02174cfc-9412-4cfe-afbf-59f706d72cf6" });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cfc-9412-4cfe-afbf-59f706d72cf6");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { "A comprehensive guide to C# programming.", null, "C# Programming Book", 350m, 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 2, "A high-performance laptop for all your computing needs.", null, "Laptop", 8499m, 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 3, "A comfortable and stylish t-shirt.", null, "T-Shirt", 79.99m, 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 4, "A powerful blender for your kitchen.", null, "Blender", 650m, 20 });
        }
    }
}
