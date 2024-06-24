using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeverageInventoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangeQuantityToStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Beverages",
                newName: "Stock");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Beverages",
                newName: "Quantity");
        }
    }
}
