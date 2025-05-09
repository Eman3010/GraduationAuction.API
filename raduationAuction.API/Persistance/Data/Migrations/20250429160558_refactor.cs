using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationAuction.API.Persistance.Data.Migrations
{
    /// <inheritdoc />
    public partial class refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BuyerPayments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BidTime",
                table: "Bids",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Auctionid",
                table: "Bids",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "itemid",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryID",
                table: "Items",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPayments_BiddingID",
                table: "BuyerPayments",
                column: "BiddingID");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPayments_UserId",
                table: "BuyerPayments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_Auctionid",
                table: "Bids",
                column: "Auctionid");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_itemid",
                table: "Auctions",
                column: "itemid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_UserId",
                table: "Auctions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Items_itemid",
                table: "Auctions",
                column: "itemid",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Users_UserId",
                table: "Auctions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Auctions_Auctionid",
                table: "Bids",
                column: "Auctionid",
                principalTable: "Auctions",
                principalColumn: "AuctionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerPayments_Bids_BiddingID",
                table: "BuyerPayments",
                column: "BiddingID",
                principalTable: "Bids",
                principalColumn: "BiddingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerPayments_Users_UserId",
                table: "BuyerPayments",
                column: "BuyerUserID",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryID",
                table: "Items",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Items_itemid",
                table: "Auctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Users_UserId",
                table: "Auctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Auctions_Auctionid",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_BuyerPayments_Bids_BiddingID",
                table: "BuyerPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_BuyerPayments_Users_UserId",
                table: "BuyerPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_BuyerPayments_BiddingID",
                table: "BuyerPayments");

            migrationBuilder.DropIndex(
                name: "IX_BuyerPayments_UserId",
                table: "BuyerPayments");

            migrationBuilder.DropIndex(
                name: "IX_Bids_Auctionid",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_itemid",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_UserId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BuyerPayments");

            migrationBuilder.DropColumn(
                name: "Auctionid",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "itemid",
                table: "Auctions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BidTime",
                table: "Bids",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
