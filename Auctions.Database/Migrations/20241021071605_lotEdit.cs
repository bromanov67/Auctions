using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auctions.Database.Migrations
{
    /// <inheritdoc />
    public partial class lotEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MinPrice",
                table: "Lots",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RansomPrice",
                table: "Lots",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinPrice",
                table: "Lots");

            migrationBuilder.DropColumn(
                name: "RansomPrice",
                table: "Lots");
        }
    }
}
