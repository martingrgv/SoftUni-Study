using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Migrations
{
    public partial class guestuser_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "06b1c132-083d-4566-aaa0-a76d31934bd2", 0, "eeb9f48c-a06d-41e5-8624-e3fc274cfa7c", "guest@mail.com", false, false, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAEAACcQAAAAEPDGcQQun6eeU32ejjar2U/L5bIVMcOF+8iuMR3oTMeceY/uVb7gtB4RxH1DhBUszw==", null, false, "0389d778-6e85-4869-bccb-5a278c7b072f", false, "guest@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06b1c132-083d-4566-aaa0-a76d31934bd2");
        }
    }
}
