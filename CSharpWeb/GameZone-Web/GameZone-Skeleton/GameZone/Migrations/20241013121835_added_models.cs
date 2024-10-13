using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Migrations
{
    public partial class added_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06b1c132-083d-4566-aaa0-a76d31934bd2");

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
                values: new object[] { "d9b49728-4852-4699-958d-64d79549b736", 0, "9b1de318-b449-421d-a547-53a4e8bf82db", "guest@mail.com", false, false, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAEAACcQAAAAELrSruc72wCVEcty9xS7gsx1lJW3O4RmzU90apQnvMGz5hIROJ3YdaTY+0GXf4W7xg==", null, false, "eceb6cfa-3b94-4b12-a474-5cf96f55349b", false, "guest@mail.com" });

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
                keyValue: "d9b49728-4852-4699-958d-64d79549b736");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "06b1c132-083d-4566-aaa0-a76d31934bd2", 0, "eeb9f48c-a06d-41e5-8624-e3fc274cfa7c", "guest@mail.com", false, false, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAEAACcQAAAAEPDGcQQun6eeU32ejjar2U/L5bIVMcOF+8iuMR3oTMeceY/uVb7gtB4RxH1DhBUszw==", null, false, "0389d778-6e85-4869-bccb-5a278c7b072f", false, "guest@mail.com" });
        }
    }
}
