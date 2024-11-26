using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 21, "user:municipalityId", "", "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3" },
                    { 22, "user:municipalityName", "", "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3" },
                    { 23, "user:municipalityCode", "", "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3" },
                    { 24, "user:fullname", "Стоян Георгиев", "22ad10a0-2f69-4735-bd2c-9e944cd80baf" },
                    { 25, "user:municipalityId", "16", "22ad10a0-2f69-4735-bd2c-9e944cd80baf" },
                    { 26, "user:municipalityName", "Бургас", "22ad10a0-2f69-4735-bd2c-9e944cd80baf" },
                    { 29, "user:municipalityId", "32", "faf648ad-8f38-459d-909f-256f9a167a44" },
                    { 30, "user:municipalityName", "Варна", "faf648ad-8f38-459d-909f-256f9a167a44" },
                    { 31, "user:municipalityCode", "5305", "faf648ad-8f38-459d-909f-256f9a167a44" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28c27a9a-7203-4c01-8f98-e831c8baf209", "AQAAAAIAAYagAAAAENw+macK2mEnykM3L42fuy3Zg8hLM5xvfYYG1hl4uKzLZcvCrdZDxOK2yx5JyXZ1ag==", "e4f3a3f1-c482-48f3-a5d5-395c96815e1a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bdacf09-bbb0-4562-bafd-186ab2d0608e", "AQAAAAIAAYagAAAAENZvLvmYG0f1YAfUYQWoB9i91r81tXkQPSy0K6DyDQcig8JSt7X8x6+Uhu4yqoSeOg==", "8f607de3-94f3-4ba3-8c9b-eb636a4f16dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a721a9de-924a-4f2f-a34c-0d3833920eba", "AQAAAAIAAYagAAAAEOtEfwvmEFWuG8AZ052p0PLs4/1PEWM8PjTFv7/6mf140z4KF4UdFPPXnDscpRwhRw==", "0d515f81-7945-4a8b-8db9-c90e356ef8f3" });
        }
    }
}
