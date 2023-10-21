using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace huutokauppa.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParticipateId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParticipateId",
                table: "Bids",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Participates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participates_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "AuctionStartDate",
                value: new DateTime(2023, 10, 21, 13, 1, 16, 833, DateTimeKind.Local).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "AuctionStartDate",
                value: new DateTime(2023, 10, 21, 13, 1, 16, 833, DateTimeKind.Local).AddTicks(3225));

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParticipateId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParticipateId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ParticipateId", "Timestamp" },
                values: new object[] { null, new DateTime(2023, 10, 21, 10, 1, 16, 833, DateTimeKind.Utc).AddTicks(3355) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ParticipateId", "Timestamp" },
                values: new object[] { null, new DateTime(2023, 10, 21, 10, 1, 16, 833, DateTimeKind.Utc).AddTicks(3359) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ParticipateId", "Timestamp" },
                values: new object[] { null, new DateTime(2023, 10, 21, 10, 1, 16, 833, DateTimeKind.Utc).AddTicks(3361) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ParticipateId", "Timestamp" },
                values: new object[] { null, new DateTime(2023, 10, 21, 10, 1, 16, 833, DateTimeKind.Utc).AddTicks(3362) });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ParticipateId",
                table: "Messages",
                column: "ParticipateId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ParticipateId",
                table: "Bids",
                column: "ParticipateId");

            migrationBuilder.CreateIndex(
                name: "IX_Participates_AuctionId",
                table: "Participates",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Participates_UserId",
                table: "Participates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Participates_ParticipateId",
                table: "Bids",
                column: "ParticipateId",
                principalTable: "Participates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Participates_ParticipateId",
                table: "Messages",
                column: "ParticipateId",
                principalTable: "Participates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Participates_ParticipateId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Participates_ParticipateId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Participates");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ParticipateId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Bids_ParticipateId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "ParticipateId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ParticipateId",
                table: "Bids");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "AuctionStartDate",
                value: new DateTime(2023, 10, 20, 18, 12, 11, 91, DateTimeKind.Local).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "AuctionStartDate",
                value: new DateTime(2023, 10, 20, 18, 12, 11, 91, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 20, 15, 12, 11, 91, DateTimeKind.Utc).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 20, 15, 12, 11, 91, DateTimeKind.Utc).AddTicks(7455));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2023, 10, 20, 15, 12, 11, 91, DateTimeKind.Utc).AddTicks(7457));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2023, 10, 20, 15, 12, 11, 91, DateTimeKind.Utc).AddTicks(7458));
        }
    }
}
