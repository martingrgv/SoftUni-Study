using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Migrations
{
    public partial class ModelsAndSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReleasedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_AspNetUsers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamersGames",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GamerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamersGames", x => new { x.GameId, x.GamerId });
                    table.ForeignKey(
                        name: "FK_GamersGames_AspNetUsers_GamerId",
                        column: x => x.GamerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GamersGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5067afe2-1093-4328-ac98-34ecfdf90937", 0, "71627110-7e3a-40ae-8d28-8054f823a607", "guest@mail.com", false, false, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAEAACcQAAAAECd3DQWgLHSDHYTv9KOHNc88fHadW56PGNLYgj8QUUIvnZPuBpgmOrMan9++hm19bg==", null, false, "77ecb5ae-072d-4448-815c-3baaedaa2fd2", false, "guest@mail.com" },
                    { "5615c548-7c51-4df4-8630-187395bc1c01", 0, "e7f47e7b-adf2-47e0-9e36-6606c81e008b", "publisher@mail.com", false, false, null, "PUBLISHER@MAIL.COM", "PUBLISHER@MAIL.COM", "AQAAAAEAACcQAAAAEC8SbNAHM0Ti1b9QxRdAkmicsS002SIJ8q7LI4u+8iI6c/JOItGvEpAS3zSB7kBeRg==", null, false, "519da165-1214-487f-9f07-299bd16b6b2b", false, "publisher@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Fighting" },
                    { 4, "Sports" },
                    { 5, "Racing" },
                    { 6, "Strategy" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "GenreId", "ImageUrl", "PublisherId", "ReleasedOn", "Title" },
                values: new object[] { 1, "Assassin's Creed Mirage is a 2023 action-adventure game developed by Ubisoft Bordeaux and published by Ubisoft.The game is the thirteenth major installment in the Assassin's Creed series and the successor to 2020's Assassin's Creed Valhalla.While its historical timeframe precedes that of", 1, "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimages.wallpapersden.com%2Fimage%2Fdownload%2Fofficial-assassin-s-creed-mirage-hd_bWtoZmiUmZqaraWkpJRobWllrWdma2VnZWc.jpg&f=1&nofb=1&ipt=72fbe60bee574d188b5189ac5f601188088d9beaf9d22af8f42488f8bf052da9&ipo=images", "5615c548-7c51-4df4-8630-187395bc1c01", new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assassin's Creed Mirage" });

            migrationBuilder.CreateIndex(
                name: "IX_GamersGames_GamerId",
                table: "GamersGames",
                column: "GamerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamersGames");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5067afe2-1093-4328-ac98-34ecfdf90937");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5615c548-7c51-4df4-8630-187395bc1c01");
        }
    }
}
