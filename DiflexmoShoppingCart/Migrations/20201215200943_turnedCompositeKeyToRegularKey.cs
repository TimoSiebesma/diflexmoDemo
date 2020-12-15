using Microsoft.EntityFrameworkCore.Migrations;

namespace DiflexmoShoppingCart.Migrations
{
    public partial class turnedCompositeKeyToRegularKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductShoppingCarts",
                table: "ProductShoppingCarts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductShoppingCarts",
                table: "ProductShoppingCarts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShoppingCarts_ProductId",
                table: "ProductShoppingCarts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductShoppingCarts",
                table: "ProductShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductShoppingCarts_ProductId",
                table: "ProductShoppingCarts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductShoppingCarts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductShoppingCarts",
                table: "ProductShoppingCarts",
                columns: new[] { "ProductId", "ShoppingCartId" });
        }
    }
}
