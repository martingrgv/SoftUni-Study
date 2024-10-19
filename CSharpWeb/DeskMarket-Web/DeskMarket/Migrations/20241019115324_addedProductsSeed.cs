using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeskMarket.Migrations
{
    /// <inheritdoc />
    public partial class addedProductsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5067afe2-1093-4328-ac98-34ecfdf90937",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ec193f3-62da-460b-99f6-74001df19ec9", "AQAAAAIAAYagAAAAEEKQ3ucXD5xHPcWTpiPFnfYG5E0RwFG5zqfbNdTyiNNIgMd0lhBi4PlFNTB8mRanHw==", "815ec78c-3469-485d-a202-6e3a711b3d0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5615c548-7c51-4df4-8630-187395bc1c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80750d16-5f5f-448c-8429-e31d750f971b", "AQAAAAIAAYagAAAAEF3xeJ7t8m6LOt3+cek1cVu88V/jSBUUlLRZ8jC99N3Lvl38K+0iSXafx2WagTdsVQ==", "e136492d-2e33-4af2-89ea-52b9916981f7" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedOn", "CategoryId", "Description", "ImageUrl", "Price", "ProductName", "SellerId" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "NEW!!! BEST!!! Macbook Pro 14 with M3 CHIP!!! CHIP REMAP AT TOSHOMACS!'not overpriced'", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fmacfinder.co.uk%2Fwp-content%2Fuploads%2F2022%2F12%2Fimg-MacBook-Pro-Retina-14-Inch-23934.jpg&f=1&nofb=1&ipt=02616d587eadae93c5847e57417fd50aff3d58046e2bc3c2c507c32750e0b78a&ipo=images", 2999.99m, "Macbook Pro 14", "5615c548-7c51-4df4-8630-187395bc1c01" },
                    { 3, new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Hamster holding your cables", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpbs.twimg.com%2Fmedia%2FFZlrXO2XgAE2JjC.jpg&f=1&nofb=1&ipt=1202248bad871aafac655c8e11f148bf9b614bbfc4784bcca147402901caee3b&ipo=images", 5.99m, "Hamster cable holder", "5615c548-7c51-4df4-8630-187395bc1c01" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5067afe2-1093-4328-ac98-34ecfdf90937",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb930112-5751-4b83-959f-b3e78917c59a", "AQAAAAIAAYagAAAAEMuHsby48JiDYWvfQB3e/Q49SV6Nvx34mruxH9jrqdkpFB2LUxGJT0tkwffHpYEi+w==", "bdf5a9d3-a182-4fc3-a6c2-e917b8c04453" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5615c548-7c51-4df4-8630-187395bc1c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "341e9758-8e14-4d3b-886e-6d5e67aeb141", "AQAAAAIAAYagAAAAEFW5VUVPTbytAhc2zOjavEugZ/joLRL0K3aCqw/ULV7xjEPEofilzu892/H0aAR4vw==", "fc1d7dfd-de72-4e83-bb72-e49921658bde" });
        }
    }
}
