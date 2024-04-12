using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Padrao_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Preco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Item",
                type: "numeric");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Item");
        }
    }
}
