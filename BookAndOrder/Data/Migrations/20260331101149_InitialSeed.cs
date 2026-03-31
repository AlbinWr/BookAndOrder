using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAndOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cfc-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af79bad0-909f-40ae-9f64-44776551c8fd", "AQAAAAIAAYagAAAAEE/qrAw5WDNcJH8l3G0ny9lVijKXwndJQ+IpM1moppOe9v4JNLEnR8PoHTNolxrCEA==", "f8597103-8761-475c-a92b-944dce2198a7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cfc-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a65eddf2-2bc0-45e3-b395-669a0dd2147f", "AQAAAAIAAYagAAAAEDkVJzWCl2+6TAboe6pak9+ChvU4+5gEIoolR1MpgI22jbf48RpvAkWcM0Aj5pONHA==", "05cf4618-16ba-4a26-aa65-1220a3c05e6c" });
        }
    }
}
