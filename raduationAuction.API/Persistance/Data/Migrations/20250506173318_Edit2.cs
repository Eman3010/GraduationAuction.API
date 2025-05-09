using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationAuction.API.Persistance.Data.Migrations
{
    /// <inheritdoc />
    public partial class Edit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pictureURL",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "AuctionName",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pictureURL",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuctionName",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "pictureURL",
                table: "Auctions");

            migrationBuilder.AddColumn<string>(
                name: "pictureURL",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
