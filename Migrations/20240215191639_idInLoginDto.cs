using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class idInLoginDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7162caf4-3625-4c63-902c-b4222e0af7ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f1318ab-8758-4182-a259-327beb87205f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0eac0d44-bebc-40f3-bd3d-74730293e9c5", null, "Administrator", "ADMINISTRATOR" },
                    { "dbc5a4d9-1508-478a-b78d-9a3f906a27ff", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eac0d44-bebc-40f3-bd3d-74730293e9c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbc5a4d9-1508-478a-b78d-9a3f906a27ff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7162caf4-3625-4c63-902c-b4222e0af7ca", null, "User", "USER" },
                    { "8f1318ab-8758-4182-a259-327beb87205f", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
