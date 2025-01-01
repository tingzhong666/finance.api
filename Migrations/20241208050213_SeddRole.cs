using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace finance.api.Migrations
{
    /// <inheritdoc />
    public partial class SeddRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c3b8e207-2bad-4ba8-9d10-614243b1d0c9", null, "Admin", "ADMIN" },
                    { "e439599b-bdb6-4bd1-a10f-91685fecfe23", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3b8e207-2bad-4ba8-9d10-614243b1d0c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e439599b-bdb6-4bd1-a10f-91685fecfe23");
        }
    }
}
