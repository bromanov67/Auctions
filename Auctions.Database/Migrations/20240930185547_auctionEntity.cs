using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auctions.Database.Migrations
{
    /// <inheritdoc />
    public partial class auctionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Auctions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCreation",
                table: "Auctions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "IsCreation",
                table: "Auctions");
        }
    }
}
