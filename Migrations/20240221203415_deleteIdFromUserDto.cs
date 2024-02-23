using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class deleteIdFromUserDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "171fdfaf-bbf0-4e18-9a96-c8660acc99ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59b672e5-c3d4-434b-8f3d-ff97f8e31d7f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c27bcbf-b700-4bd0-801b-d84f64c9645f", null, "Administrator", "ADMINISTRATOR" },
                    { "c99e5054-4c72-43f2-a3b9-e4baffa54933", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c27bcbf-b700-4bd0-801b-d84f64c9645f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c99e5054-4c72-43f2-a3b9-e4baffa54933");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "171fdfaf-bbf0-4e18-9a96-c8660acc99ed", null, "User", "USER" },
                    { "59b672e5-c3d4-434b-8f3d-ff97f8e31d7f", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
