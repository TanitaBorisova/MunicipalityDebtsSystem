using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFkDebt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1e34a72-8534-42c1-9819-101740a37f95", "AQAAAAIAAYagAAAAEEYaJ8J3PLLFcBecYXDBhcisJrs+uRmxfIJfEBEwLty65lACFd0x12wDJGjcpQjcmQ==", "3b1ed00a-c3b3-4b44-b3e4-915abfb3e0ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5d95dde-9bf9-4890-ac53-f5bbbf7a5f61", "AQAAAAIAAYagAAAAEArc7nIGcR9rqjXtlQXsNnG5t0CG9JmZrxxLHdJZ7P+x+2xXx5LXnqlUAZyWykbNOg==", "6e955c9c-a309-4343-b2ff-38ecfa5eca34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3abb334-e4e8-4050-a00d-6c0898e8f8f7", "AQAAAAIAAYagAAAAEA+0aDbI/oZYe4VudKgyEdkJqL2erExzxtszddW9XFSpQyS0GjLQhANOBE29Mjvryw==", "206ac2ca-e049-48a4-aa25-3164be07e5d3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a43867d9-1532-47d4-a159-6846dff68d0a", "AQAAAAIAAYagAAAAEJgdin4EThv3CsqjNGUKtQQbSwu9wl6GVs14wIOY/19sRZJawD7MOALu4SiQNa4UjA==", "154f3763-21c8-4141-bb1f-6401e17a2407" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed568673-8b81-426f-8c49-ba6794a2f4c1", "AQAAAAIAAYagAAAAEOSNP5vKVybSaYidQNzo4RZH6bSqz/BWTl4odaCo0xkEd5WkPG23nCBz1MS0H3V7Fw==", "97da031c-a195-4ca8-932c-9ad706d23337" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf5e3710-b0cb-41ae-8415-12b4a3cd2281", "AQAAAAIAAYagAAAAEJaVe6Z2JhsRXFBiIf0f4093kaOy1CaqKav5jEFyo/pCiDA9CVtMbbtt5G6v2L6yLg==", "dcd2e269-2eec-4eb2-9f43-d0e9539fb738" });
        }
    }
}
