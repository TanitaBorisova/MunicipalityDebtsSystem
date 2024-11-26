using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

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
                    { 20, "user:fullname", "Иван Петров", "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3" },
                    { 27, "user:municipalityCode", "5202", "22ad10a0-2f69-4735-bd2c-9e944cd80baf" },
                    { 28, "user:fullname", "Георги Василев", "faf648ad-8f38-459d-909f-256f9a167a44" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Иван Петров", "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3" },
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
    }
}
