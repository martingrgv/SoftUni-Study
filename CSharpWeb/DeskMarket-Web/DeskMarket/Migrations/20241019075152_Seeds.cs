using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeskMarket.Migrations
{
    /// <inheritdoc />
    public partial class Seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5067afe2-1093-4328-ac98-34ecfdf90937", 0, "cb930112-5751-4b83-959f-b3e78917c59a", "guest@mail.com", false, false, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAIAAYagAAAAEMuHsby48JiDYWvfQB3e/Q49SV6Nvx34mruxH9jrqdkpFB2LUxGJT0tkwffHpYEi+w==", null, false, "bdf5a9d3-a182-4fc3-a6c2-e917b8c04453", false, "guest@mail.com" },
                    { "5615c548-7c51-4df4-8630-187395bc1c01", 0, "341e9758-8e14-4d3b-886e-6d5e67aeb141", "seller@mail.com", false, false, null, "SELLER@MAIL.COM", "SELLER@MAIL.COM", "AQAAAAIAAYagAAAAEFW5VUVPTbytAhc2zOjavEugZ/joLRL0K3aCqw/ULV7xjEPEofilzu892/H0aAR4vw==", null, false, "fc1d7dfd-de72-4e83-bb72-e49921658bde", false, "seller@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Laptops" },
                    { 2, "Workstations" },
                    { 3, "Accessories" },
                    { 4, "Desktops" },
                    { 5, "Monitors" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedOn", "CategoryId", "Description", "ImageUrl", "Price", "ProductName", "SellerId" },
                values: new object[] { 1, new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "The best gaming laptop on the market!", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fmac24h.vn%2Fimages%2Fcompanies%2F1%2FLaptop%25201%2FAlienware%2520m15x%2Falienware%2520m16%2520r1.jpeg%3F1687623368228&f=1&nofb=1&ipt=31a2688bb6806164bc21e1ad12ee22fc66fc6a4886b17d32710cc760735a5b86&ipo=images", 2100m, "ALIENWARE M15 R6", "5615c548-7c51-4df4-8630-187395bc1c01" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5067afe2-1093-4328-ac98-34ecfdf90937");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5615c548-7c51-4df4-8630-187395bc1c01");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
