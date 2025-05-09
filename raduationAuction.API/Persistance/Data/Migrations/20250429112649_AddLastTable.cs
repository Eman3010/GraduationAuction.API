using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationAuction.API.Persistance.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLastTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyerPayments",
                columns: table => new
                {
                    BiddingID = table.Column<int>(type: "int", nullable: false),
                    BuyerUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerPayments", x => new { x.BuyerUserID, x.BiddingID });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerPayments");
        }
    }
}
