using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAndOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cfc-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b30dba3b-a84c-41c9-a82c-9ee2b903459d", "AQAAAAIAAYagAAAAECadD5qU+CXOtezTkoChqKrB9jZ/87/FB3sw943Bs0n3fxGYpGVUzhFmR39mdsdLXQ==", "96ec5ee9-564b-416d-a66e-438e716b36ef" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "A deep dive into modern C# features.", "https://images.unsplash.com/photo-1516116216624-53e697fedbea?w=400&h=400&fit=crop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Professionalism in software development.", "https://images.unsplash.com/photo-1544716278-ca5e3f4abd8c?w=400&h=400&fit=crop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Bridge the gap to databases.", "https://images.unsplash.com/photo-1555066931-4365d14bab8c?w=400&h=400&fit=crop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Noise-canceling over-ear headphones.", "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=400&h=400&fit=crop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "RGB backlit mechanical keyboard.", "https://images.unsplash.com/photo-1511467687858-23d96c32e4ae?w=400&h=400&fit=crop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Fitness tracker with heart rate monitor.", "https://images.unsplash.com/photo-1508685096489-7aac291acd5b?w=400&h=400&fit=crop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "34-inch curved display.", "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=400&h=400&fit=crop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Warm, comfortable hoodie.", "https://images.unsplash.com/photo-1556821840-3a63f95609a7?w=400&h=400&fit=crop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Classic blue denim jacket.", "https://images.unsplash.com/photo-1576871337622-98d48d890e49?w=400&h=400&fit=crop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Durable and stylish boots.", "https://images.unsplash.com/photo-1520639889456-7400030f8783?w=400&h=400&fit=crop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Automatic espresso machine.", "https://images.unsplash.com/photo-1510591509098-f4fdc6d0ff04?w=400&h=400&fit=crop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Healthy cooking with 90% less oil.", "https://images.unsplash.com/photo-1584269600464-37b1b58a9fe7?w=400&h=400&fit=crop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Professional stainless steel knives.", "https://images.unsplash.com/photo-1593618998160-e34014e67546?w=400&h=400&fit=crop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Heavy-duty skillet for perfect searing.", "https://images.unsplash.com/photo-1594140720491-140306263595?w=400&h=400&fit=crop" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cfc-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af79bad0-909f-40ae-9f64-44776551c8fd", "AQAAAAIAAYagAAAAEE/qrAw5WDNcJH8l3G0ny9lVijKXwndJQ+IpM1moppOe9v4JNLEnR8PoHTNolxrCEA==", "f8597103-8761-475c-a92b-944dce2198a7" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "A deep dive into modern C# features and asynchronous programming patterns.", "https://picsum.photos/id/24/400/400" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Professionalism, pragmatism, and pride in the art of software development.", "https://picsum.photos/id/1/400/400" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Learn how to bridge the gap between object-oriented code and relational databases.", "https://picsum.photos/id/2/400/400" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Noise-canceling over-ear headphones with 40-hour battery life and premium sound.", "https://picsum.photos/id/3/400/400" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "RGB backlit mechanical keyboard with tactile switches for gaming and office work.", "https://picsum.photos/id/4/400/400" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Fitness tracker with heart rate monitor, GPS, and waterproof design.", "https://picsum.photos/id/5/400/400" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "34-inch curved display perfect for multitasking and immersive gaming experiences.", "https://picsum.photos/id/6/400/400" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Warm, comfortable hoodie made from 100% organic cotton. Perfect for winter.", "https://picsum.photos/id/7/400/400" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Classic blue denim jacket with a modern fit and high-quality stitching.", "https://picsum.photos/id/8/400/400" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Durable and stylish leather boots for all-weather exploration.", "https://picsum.photos/id/9/400/400" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Automatic espresso machine with built-in grinder for the perfect morning coffee.", "https://picsum.photos/id/10/400/400" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Healthy cooking with 90% less oil. Large capacity for family dinners.", "https://picsum.photos/id/11/400/400" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Professional 5-piece stainless steel knife set with ergonomic wooden handles.", "https://picsum.photos/id/12/400/400" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Heavy-duty skillet for perfect searing and even heat distribution.", "https://picsum.photos/id/13/400/400" });
        }
    }
}
