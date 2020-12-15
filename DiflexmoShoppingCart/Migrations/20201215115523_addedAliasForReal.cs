using Microsoft.EntityFrameworkCore.Migrations;

namespace DiflexmoShoppingCart.Migrations
{
    public partial class addedAliasForReal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "ShoppingCarts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "ShoppingCarts");
        }
    }
}
