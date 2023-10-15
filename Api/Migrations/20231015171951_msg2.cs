using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace huutokauppa.Migrations
{
    /// <inheritdoc />
    public partial class msg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormattedTimeStamp",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 15, 17, 19, 51, 287, DateTimeKind.Utc).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 15, 17, 19, 51, 287, DateTimeKind.Utc).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2023, 10, 15, 17, 19, 51, 287, DateTimeKind.Utc).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2023, 10, 15, 17, 19, 51, 287, DateTimeKind.Utc).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2023, 10, 15, 17, 19, 51, 287, DateTimeKind.Utc).AddTicks(8352));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormattedTimeStamp",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FormattedTimeStamp", "Timestamp" },
                values: new object[] { null, new DateTime(2023, 10, 15, 13, 15, 17, 951, DateTimeKind.Utc).AddTicks(5003) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FormattedTimeStamp", "Timestamp" },
                values: new object[] { null, new DateTime(2023, 10, 15, 13, 15, 17, 951, DateTimeKind.Utc).AddTicks(5008) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FormattedTimeStamp", "Timestamp" },
                values: new object[] { null, new DateTime(2023, 10, 15, 13, 15, 17, 951, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FormattedTimeStamp", "Timestamp" },
                values: new object[] { null, new DateTime(2023, 10, 15, 13, 15, 17, 951, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FormattedTimeStamp", "Timestamp" },
                values: new object[] { null, new DateTime(2023, 10, 15, 13, 15, 17, 951, DateTimeKind.Utc).AddTicks(5011) });
        }
    }
}
