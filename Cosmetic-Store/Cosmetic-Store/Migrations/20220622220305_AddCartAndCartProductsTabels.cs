using Microsoft.EntityFrameworkCore.Migrations;

namespace Cosmetic_Store.Migrations
{
    public partial class AddCartAndCartProductsTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => new { x.CartID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8ff",
                column: "ConcurrencyStamp",
                value: "c5e07644-9418-4562-9252-d4fe0d1e64ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd586a8ff",
                column: "ConcurrencyStamp",
                value: "e513ac40-e415-42e4-b0f3-c0248a297072");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abcbe9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d9d347a6-9dee-43c1-b496-291714bf4137", "AQAAAAEAACcQAAAAEP7MmaPaQlq0Gp4gCTEiyLmJMJqhd9weL4Vl9ek8IbickYz3dz+3NFakpCxl2utUzA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abcze710",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e618e240-e9fe-4218-9a2f-6cccbdc470ca", "AQAAAAEAACcQAAAAEHKtXjI9xuMaPgAaqqxKOWJOwsHTblSIllVQrjq+EYxQcQetxMcnW0Mqv5b1IWSYMA==" });

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductID",
                table: "CartProducts",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8ff",
                column: "ConcurrencyStamp",
                value: "dad09590-92f7-40ef-a1b6-56dc361a80f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd586a8ff",
                column: "ConcurrencyStamp",
                value: "b71a43b6-802c-4aa2-b60b-7b2651155dde");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abcbe9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b4d1ab7a-784f-409d-8e19-f0fb9346c5b3", "AQAAAAEAACcQAAAAEDwOvvk98i2Pq4l8B3jF2k3CTkOIb0XIAIrs80AJ9rX0I5tNsTFF3G3Fk+3Xpy2yhQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abcze710",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb266628-65c0-495c-bd1a-5b21953857c9", "AQAAAAEAACcQAAAAEIAyjkTwC24zuODbxyV0v5cP5hIUWfiXsahPTwQlU2hGbTkPAGTgWJtQfomB6f4PTQ==" });
        }
    }
}
