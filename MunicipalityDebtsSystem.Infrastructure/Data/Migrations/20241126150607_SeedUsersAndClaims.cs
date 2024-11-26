using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersAndClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Иван Петров", "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3" },
                    { 2, "user:fullname", "Стоян Георгиев", "22ad10a0-2f69-4735-bd2c-9e944cd80baf" },
                    { 3, "user:fullname", "Георги Василев", "faf648ad-8f38-459d-909f-256f9a167a44" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90f65349-9e89-4800-b239-02597095b74d", "BURGAS_MUNICIPAL@MAIL.BG", "BURGAS_MUNICIPAL@MAIL.BG", "AQAAAAIAAYagAAAAEBjiazLG/HvbrNc2eTVXNtlgXVD8IEP78wtw2e7M3dGN+AyClo0WFYBmLPx3QTnoPg==", "c8f74506-9f68-44ff-862d-9896fe3f39d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "679f0196-9633-4df5-a3c2-bc35a5ccf510", "ADMINDEBT@MAIL.COM", "ADMINDEBT@MAIL.COM", "AQAAAAIAAYagAAAAEMZ0G8MAXsj9hdpdKqUWGyDDO5z13UL9FIKUpRG3BLEjvqImFBvxcNnEmhyNF+GRQg==", "b21426ae-33b6-47fd-be53-bd0f167d0959" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fda462f4-7bbe-4691-b84d-69a22023cd48", "VARNAMUN@MAIL.COM", "VARNAMUN@MAIL.COM", "AQAAAAIAAYagAAAAEI5byiBc4c2RL+gi9Q8YKTrR35JHnTFB3wdPaOTTQ4K9hN/5gz48beXTQb/DzMr6HA==", "099b6693-ecc3-402e-88de-959b6b7199e1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c834c3e-9d0d-489f-a045-c960fea4b4b3", "burgas_municipal@mail.bg", "burgas_municipal@mail.bg", "AQAAAAIAAYagAAAAEJLmFAOZZAiMojHrzqDoQs+6RsLE/UWcBFemfGwvttiOEtk+Wp+IP1TunWBk5XhyqA==", "0e8e3802-21cb-4328-a64e-9c637244424a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16d70716-b79d-4c2d-a2db-3e52af407e93", "admindebt@mail.bg", "admindebt@mail.com", "AQAAAAIAAYagAAAAEOYEfK3kDPbqvOgA6zGD4stYqd9GDyQgyvt3APsEjMQFvYV3sXBuVQ42UywqExQi8g==", "c2e5ba44-b4f3-478e-b419-82c9bf7fa5e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ebe5fa5-1a48-4440-8b49-5d8cb90247ef", "varnamun@mail.com", "varnamun@mail.com", null, "d8d35cd8-38e1-4f71-b944-107b274786b3" });
        }
    }
}
