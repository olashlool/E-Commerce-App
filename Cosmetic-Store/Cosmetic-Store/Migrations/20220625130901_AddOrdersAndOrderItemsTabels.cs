using Microsoft.EntityFrameworkCore.Migrations;

namespace Cosmetic_Store.Migrations
{
    public partial class AddOrdersAndOrderItemsTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderItems_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductID",
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
                value: "84d9d096-58d7-4d83-a123-18c0f40697b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd586a8ff",
                column: "ConcurrencyStamp",
                value: "861bd4f4-a521-4502-a066-240687a90c72");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abcbe9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "896f21fc-7998-4206-92c5-35ae0c6c1b4a", "AQAAAAEAACcQAAAAEDW1Wi+lxluc6E3rdMH6iD+kNvSB6ztEntheHP7jIp6odAk8D/tUT5SsMqrVKhR8EA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abcze710",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88137585-9fcc-4e21-8a22-b7561ca8fbd6", "AQAAAAEAACcQAAAAEETdvxc/BVf/6+n5Kiv30CW5ddOolQ9KWCRZJz29LBgyQYreajpEWzxs2i2m8STZVg==" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductID",
                table: "OrderItems",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Order");

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
        }
    }
}
