using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationAuction.API.Persistance.Data.Migrations
{
    /// <inheritdoc />
    public partial class lastedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Users_UserId",
                table: "Auctions");

            migrationBuilder.DropTable(
                name: "BuyerPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Auctions",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_Auctions_UserId",
                table: "Auctions",
                newName: "IX_Auctions_userid");

            migrationBuilder.AddColumn<int>(
                name: "BuyerUserId",
                table: "Bids",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_BuyerUserId",
                table: "Bids",
                column: "BuyerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_User_userid",
                table: "Auctions",
                column: "userid",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_User_BuyerUserId",
                table: "Bids",
                column: "BuyerUserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_User_userid",
                table: "Auctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_User_BuyerUserId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_BuyerUserId",
                table: "Bids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BuyerUserId",
                table: "Bids");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Auctions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Auctions_userid",
                table: "Auctions",
                newName: "IX_Auctions_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BuyerPayments",
                columns: table => new
                {
                    BuyerUserID = table.Column<int>(type: "int", nullable: false),
                    BiddingID = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerPayments", x => new { x.BuyerUserID, x.BiddingID });
                    table.ForeignKey(
                        name: "FK_BuyerPayments_Bids_BiddingID",
                        column: x => x.BiddingID,
                        principalTable: "Bids",
                        principalColumn: "BiddingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyerPayments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPayments_BiddingID",
                table: "BuyerPayments",
                column: "BiddingID");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPayments_UserId",
                table: "BuyerPayments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Users_UserId",
                table: "Auctions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
