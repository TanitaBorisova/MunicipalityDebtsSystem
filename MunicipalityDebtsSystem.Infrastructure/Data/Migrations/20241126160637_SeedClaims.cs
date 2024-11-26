using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 8, "user:municipalityCode", "5202", "22ad10a0-2f69-4735-bd2c-9e944cd80baf" },
                    { 17, "user:fullname", "Георги Василев", "faf648ad-8f38-459d-909f-256f9a167a44" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63a5d9de-6fd5-4c24-8249-9e07b749b7af", "AQAAAAIAAYagAAAAEMy2wuNNceRsOY5tJeEdPAGzeDqpwd1fEObzXuZ9xzrECpJEHxrR+h794okScRrafg==", "cd81e33c-c6d5-46a4-b8a9-bc16553fcdc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2584079-8657-4317-9254-cf4360137b05", "AQAAAAIAAYagAAAAEFcR2yyTZRqbgc/sou+k5r8p1FuaWVJdwOA+F5SMGDt/EDkAdh6GygAFQh5kvRpbKQ==", "f06360cc-d366-4c4e-86ad-60260d828652" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21b72a31-c3f5-4cd5-935c-e26d8d5bb74f", "AQAAAAIAAYagAAAAEJouhVxQT7N4sc3b8DCIV6Tk+KfqR6TNzduKeaLYq1kAC2IGAdN/d6/J/9wvZGjX4g==", "27ae7f5e-a84b-43bf-a6a3-9dde2be44391" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 2, "user:fullname", "Стоян Георгиев", "22ad10a0-2f69-4735-bd2c-9e944cd80baf" },
                    { 3, "user:fullname", "Георги Василев", "faf648ad-8f38-459d-909f-256f9a167a44" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90f65349-9e89-4800-b239-02597095b74d", "AQAAAAIAAYagAAAAEBjiazLG/HvbrNc2eTVXNtlgXVD8IEP78wtw2e7M3dGN+AyClo0WFYBmLPx3QTnoPg==", "c8f74506-9f68-44ff-862d-9896fe3f39d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "679f0196-9633-4df5-a3c2-bc35a5ccf510", "AQAAAAIAAYagAAAAEMZ0G8MAXsj9hdpdKqUWGyDDO5z13UL9FIKUpRG3BLEjvqImFBvxcNnEmhyNF+GRQg==", "b21426ae-33b6-47fd-be53-bd0f167d0959" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fda462f4-7bbe-4691-b84d-69a22023cd48", "AQAAAAIAAYagAAAAEI5byiBc4c2RL+gi9Q8YKTrR35JHnTFB3wdPaOTTQ4K9hN/5gz48beXTQb/DzMr6HA==", "099b6693-ecc3-402e-88de-959b6b7199e1" });
        }
    }
}
