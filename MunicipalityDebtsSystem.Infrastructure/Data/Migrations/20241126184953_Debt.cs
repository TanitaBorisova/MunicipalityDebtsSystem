using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Debt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abd7655a-340a-41ce-947f-15a6681ff185", "AQAAAAIAAYagAAAAEAiz+8ONb9i9Yfi6SOiTw52chiM80AV0oS7RhC9szB+CKa5d6NDrRIL4JZTUN5vnpw==", "eb88a680-0616-479f-a71c-b2317d0ab126" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b63f9c8d-6f2d-47ff-ac15-9cb8715cc9ce", "AQAAAAIAAYagAAAAEOrRqgn5d2DWsfc3nwEIUWjVPuOHX4bjSNxnVEQa+RnuxGv2ig0CaCWiKEcKIhozDw==", "6f06202e-325f-4fd8-8a2b-7a065378dbad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1e9510e-5075-4b57-9731-988e708f49af", "AQAAAAIAAYagAAAAEGeL8YMWJMaPt2VGEZhaKZmU0OzvAiijUb4rru8rc3DLf3T35Fu+N6iT0bgeDC8YzA==", "1afe33b6-a67c-470a-bcb1-dd7bf68db6b5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff6fa05d-e0ad-46c9-9452-aaacab2169fa", "AQAAAAIAAYagAAAAEA1Oxcrvv3wcinIMI/ucoVQMutXw5pvtWYWvJ/35LE0eMt4bJpWg/Fpp4ZeFRNM/Jw==", "a2418a01-cd10-45aa-acd0-b98ca98072d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cef9d57-2949-4622-ad62-85d8d2ac3059", "AQAAAAIAAYagAAAAEJD0LQWmvxRxDpSD/Yzhk9C1tBACv4E/ufXeDWAgRuxn/138/KyIfNd1AYKXoN+PsA==", "96c6c48a-e3d8-463b-9d2f-67ec7f789e50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "242c1872-8145-4be3-af63-7750a173a59a", "AQAAAAIAAYagAAAAEOkf5zwEuawCouG006tetIl2ueV1LmA/5Y7k2fjTj26HbkjurBQBbCKGrRYLnyjj5A==", "19436103-54d8-4db9-9acb-e9629f4a8491" });
        }
    }
}
