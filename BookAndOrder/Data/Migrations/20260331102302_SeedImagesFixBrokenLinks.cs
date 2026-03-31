using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAndOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedImagesFixBrokenLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cfc-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7cbf6db-9ed7-490e-8bf6-946880ffe0d0", "AQAAAAIAAYagAAAAEBrS/mO3m6/usCm3EiiOS7/aU832iF8Tu/yl/Z/Iaa9uxonsQXHr59fEw6Be7n56Jw==", "4d978dd7-56cf-44dc-8b8d-8a754104affc" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1579586337278-3befd40fd17a?q=80&w=1472&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1537465978529-d23b17165b3b?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1511283402428-355853756676?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1716488286931-79cef654e08c?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8Q2FzdCUyMGlyb258ZW58MHx8MHx8fDA%3D");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 6,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1508685096489-7aac291acd5b?w=400&h=400&fit=crop");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1576871337622-98d48d890e49?w=400&h=400&fit=crop");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1520639889456-7400030f8783?w=400&h=400&fit=crop");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1594140720491-140306263595?w=400&h=400&fit=crop");
        }
    }
}
