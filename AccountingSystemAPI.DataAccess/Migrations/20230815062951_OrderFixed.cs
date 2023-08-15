using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingSystemAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OrderFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellingUnit",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellingUnit",
                table: "Orders");
        }
    }
}
