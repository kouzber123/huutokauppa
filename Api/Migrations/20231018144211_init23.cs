using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace huutokauppa.Migrations
{
    /// <inheritdoc />
    public partial class init23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionAuctionBidder_AuctionBidders_AuctionBiddersId",
                table: "AuctionAuctionBidder");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Users_UserId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_UserId",
                table: "Bids");

            migrationBuilder.RenameColumn(
                name: "AuctionBiddersId",
                table: "AuctionAuctionBidder",
                newName: "AuctionParticipantsId");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Bids",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "AuctionStartDate",
                value: new DateTime(2023, 10, 18, 17, 42, 11, 77, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "AuctionStartDate",
                value: new DateTime(2023, 10, 18, 17, 42, 11, 77, DateTimeKind.Local).AddTicks(5261));

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 1,
                column: "User",
                value: null);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 2,
                column: "User",
                value: null);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 14, 42, 11, 77, DateTimeKind.Utc).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 14, 42, 11, 77, DateTimeKind.Utc).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 14, 42, 11, 77, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 14, 42, 11, 77, DateTimeKind.Utc).AddTicks(5292));

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionAuctionBidder_AuctionBidders_AuctionParticipantsId",
                table: "AuctionAuctionBidder",
                column: "AuctionParticipantsId",
                principalTable: "AuctionBidders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionAuctionBidder_AuctionBidders_AuctionParticipantsId",
                table: "AuctionAuctionBidder");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Bids");

            migrationBuilder.RenameColumn(
                name: "AuctionParticipantsId",
                table: "AuctionAuctionBidder",
                newName: "AuctionBiddersId");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "AuctionStartDate",
                value: new DateTime(2023, 10, 18, 13, 53, 1, 45, DateTimeKind.Local).AddTicks(4162));

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "AuctionStartDate",
                value: new DateTime(2023, 10, 18, 13, 53, 1, 45, DateTimeKind.Local).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 10, 53, 1, 45, DateTimeKind.Utc).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 10, 53, 1, 45, DateTimeKind.Utc).AddTicks(4279));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 10, 53, 1, 45, DateTimeKind.Utc).AddTicks(4281));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 10, 53, 1, 45, DateTimeKind.Utc).AddTicks(4282));

            migrationBuilder.CreateIndex(
                name: "IX_Bids_UserId",
                table: "Bids",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionAuctionBidder_AuctionBidders_AuctionBiddersId",
                table: "AuctionAuctionBidder",
                column: "AuctionBiddersId",
                principalTable: "AuctionBidders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Users_UserId",
                table: "Bids",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
