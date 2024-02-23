using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class manytomanyUsersHoltels1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "732ce532-0b87-4c02-97c3-b7b0a64b1d2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e80d3ea7-2fe6-4e03-aeef-8fda3336aa8c");

            migrationBuilder.CreateTable(
                name: "HotelUser",
                columns: table => new
                {
                    HotelsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelUser", x => new { x.HotelsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_HotelUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HotelUser_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "171fdfaf-bbf0-4e18-9a96-c8660acc99ed", null, "User", "USER" },
                    { "59b672e5-c3d4-434b-8f3d-ff97f8e31d7f", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelUser_UsersId",
                table: "HotelUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelUser");

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
                    { "732ce532-0b87-4c02-97c3-b7b0a64b1d2a", null, "Administrator", "ADMINISTRATOR" },
                    { "e80d3ea7-2fe6-4e03-aeef-8fda3336aa8c", null, "User", "USER" }
                });
        }
    }
}
