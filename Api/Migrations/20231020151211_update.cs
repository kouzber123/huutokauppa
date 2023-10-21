using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace huutokauppa.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auctioneers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctioneers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuctioneerUser",
                columns: table => new
                {
                    AuctioneersId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctioneerUser", x => new { x.AuctioneersId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AuctioneerUser_Auctioneers_AuctioneersId",
                        column: x => x.AuctioneersId,
                        principalTable: "Auctioneers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctioneerUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctioneerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuctionDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuctionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormattedAuctionStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuctionActive = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HostName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_Auctioneers_AuctioneerId",
                        column: x => x.AuctioneerId,
                        principalTable: "Auctioneers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auctions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    IsAuctionOwner = table.Column<bool>(type: "bit", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Auctioneers",
                column: "Id",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "AuctionId", "BidAmount", "User", "UserId" },
                values: new object[,]
                {
                    { 1, null, 100.00m, null, 1 },
                    { 2, null, 150.00m, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "ProductId", "ReferenceId", "Url" },
                values: new object[,]
                {
                    { 1, null, 1, "https://example.com/1" },
                    { 2, null, 2, "https://example.com/2" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "Name", "OwnerId", "OwnerName", "Price", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://www.vehiclehistory.com/uploads/2009-BMW-3-Series.jpg", "Product 1", 1, null, 100000m, 0, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8cHJvZHVjdHxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80", "Product 2", 1, null, 150000m, 0, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSL8kys3I1xOwZeHeL_X6ncKxXK2bDd8KtX74cWYB6n&s", "Product 3", 2, null, 200000m, 0, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://purepng.com/public/uploads/large/purepng.com-ford-mustang-red-carcarvehicletransportford-961524665626mlrez.png", "Product 4", 2, null, 500000m, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Description", "Email", "Fname", "Lname", "Password", "PhoneNumber", "Photo", "Region", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Vaasankatu1", null, "john@example.com", "John", "Doe", "test123", null, "https://static.wikia.nocookie.net/lotr/images/e/e7/Gandalf_the_Grey.jpg/revision/latest?cb=20121110131754", null, null },
                    { 2, "nigstan1", null, "jane@example.com", "Jane", "Smith", "test", null, "https://static.wikia.nocookie.net/lotr/images/c/cb/Galadriel.jpg/revision/latest?cb=20151015204512", null, null }
                });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "AuctionActive", "AuctionDetails", "AuctionStartDate", "AuctioneerId", "Category", "FormattedAuctionStartDate", "HostName", "ProductId", "Region" },
                values: new object[,]
                {
                    { 1, true, "New event 1", new DateTime(2023, 10, 20, 18, 12, 11, 91, DateTimeKind.Local).AddTicks(7381), 1, "Vechicle", null, null, 1, null },
                    { 2, false, "New event 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Music", null, null, 2, null },
                    { 3, true, "New event 3", new DateTime(2023, 10, 20, 18, 12, 11, 91, DateTimeKind.Local).AddTicks(7431), 2, "Vechicle", null, null, 3, null },
                    { 4, false, "New event 4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Electronic", null, null, 4, null }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AuctionId", "Content", "IsAuctionOwner", "Sender", "Timestamp", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "I want this", true, "haggins", new DateTime(2023, 10, 20, 15, 12, 11, 91, DateTimeKind.Utc).AddTicks(7452), 1 },
                    { 2, 2, "how much", false, "haggins", new DateTime(2023, 10, 20, 15, 12, 11, 91, DateTimeKind.Utc).AddTicks(7455), 1 },
                    { 3, 2, "do you sell winter tires", true, "david", new DateTime(2023, 10, 20, 15, 12, 11, 91, DateTimeKind.Utc).AddTicks(7457), 2 },
                    { 4, 1, "no more scams!", false, "david", new DateTime(2023, 10, 20, 15, 12, 11, 91, DateTimeKind.Utc).AddTicks(7458), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctioneerUser_UserId",
                table: "AuctioneerUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_AuctioneerId",
                table: "Auctions",
                column: "AuctioneerId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_ProductId",
                table: "Auctions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AuctionId",
                table: "Bids",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AuctionId",
                table: "Messages",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProductId",
                table: "Photos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctioneerUser");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Auctioneers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
