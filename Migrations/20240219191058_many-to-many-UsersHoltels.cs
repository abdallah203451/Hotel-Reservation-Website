using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class manytomanyUsersHoltels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eac0d44-bebc-40f3-bd3d-74730293e9c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbc5a4d9-1508-478a-b78d-9a3f906a27ff");

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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelUser_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8051bc48-62ea-4df8-8a01-10728ac0ccba", null, "Administrator", "ADMINISTRATOR" },
                    { "e2bcb59a-6c35-45cf-8633-7135bc265468", null, "User", "USER" }
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
                keyValue: "8051bc48-62ea-4df8-8a01-10728ac0ccba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2bcb59a-6c35-45cf-8633-7135bc265468");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0eac0d44-bebc-40f3-bd3d-74730293e9c5", null, "Administrator", "ADMINISTRATOR" },
                    { "dbc5a4d9-1508-478a-b78d-9a3f906a27ff", null, "User", "USER" }
                });
        }
    }
}
