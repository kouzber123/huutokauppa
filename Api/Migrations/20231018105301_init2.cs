using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace huutokauppa.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HostName",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuctionStartDate", "HostName" },
                values: new object[] { new DateTime(2023, 10, 18, 13, 53, 1, 45, DateTimeKind.Local).AddTicks(4162), null });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "HostName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuctionStartDate", "HostName" },
                values: new object[] { new DateTime(2023, 10, 18, 13, 53, 1, 45, DateTimeKind.Local).AddTicks(4251), null });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 4,
                column: "HostName",
                value: null);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HostName",
                table: "Auctions");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "AuctionStartDate",
                value: new DateTime(2023, 10, 18, 13, 41, 3, 178, DateTimeKind.Local).AddTicks(6962));

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "AuctionStartDate",
                value: new DateTime(2023, 10, 18, 13, 41, 3, 178, DateTimeKind.Local).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 10, 41, 3, 178, DateTimeKind.Utc).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 10, 41, 3, 178, DateTimeKind.Utc).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 10, 41, 3, 178, DateTimeKind.Utc).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 10, 41, 3, 178, DateTimeKind.Utc).AddTicks(7053));
        }
    }
}
