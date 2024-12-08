using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PeeriodListWithMaxLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Year",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                comment: "Year of the period like string",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Year of the period like string");

            migrationBuilder.AlterColumn<string>(
                name: "UserNameUnlock",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                comment: "User unlocked the period",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "User unlocked the period");

            migrationBuilder.AlterColumn<string>(
                name: "UserNameLock",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true,
                comment: "User locked the period",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User locked the period");

            migrationBuilder.AlterColumn<string>(
                name: "Month",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "Month of the period like string",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Month of the period like string");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92fb716f-b49d-4292-8633-27b39f514ba2", "AQAAAAIAAYagAAAAEMYoy+ViY55B5Ta8VwdEVo2YwcJY2YzgifmRU6LnbzKBxLtUp69sn8PMTcedDE73Og==", "46174673-e02a-4438-ae82-9ecbb38067ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "021acb66-2ef9-45a6-b508-2b913a8ee82c", "AQAAAAIAAYagAAAAEFqk9yEZJHIDxMWdMVWWvO8aaArQDIptgHL0DJb/HLZkEL1igA6saAbgZBCHT96yuA==", "3b8e552f-87fe-4d96-93cc-22fc2a492788" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6edfab1a-4f24-405a-80a6-e9bf5eb89f85", "AQAAAAIAAYagAAAAEPWlUADeeLrMKB+r/6wNFm5kWnrcJkC0oQex35fJ1Rp5vbu+lBorquhzX1VCzGohBA==", "c39e465a-a0af-4679-9364-50e97e6ee572" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Year",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Year of the period like string",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldComment: "Year of the period like string");

            migrationBuilder.AlterColumn<string>(
                name: "UserNameUnlock",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(max)",
                nullable: false,
                comment: "User unlocked the period",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldComment: "User unlocked the period");

            migrationBuilder.AlterColumn<string>(
                name: "UserNameLock",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User locked the period",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldNullable: true,
                oldComment: "User locked the period");

            migrationBuilder.AlterColumn<string>(
                name: "Month",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Month of the period like string",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "Month of the period like string");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "697d9bd4-5f2b-4028-9c87-8f10fabdbcd0", "AQAAAAIAAYagAAAAEPfQVnxx39MIwiqhFJRF0JKHdQj247GfrqDYGo0X+ueyaEWqMW13MzqZyjuXHjTx4w==", "a339fad8-3d47-4dd2-9d78-6813f43bcb91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c31740ee-5471-448a-aaa6-1f1393c54292", "AQAAAAIAAYagAAAAEBkxNdaqGEMWYiH8cxSjUMPNQPuae0WIGZseOVEBvlQnVy96uNLpUs6kkEuAHiPJPA==", "3c277d8f-f572-4174-945f-f642aeafbb80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d12f4301-f324-4725-ba01-33633e0900ea", "AQAAAAIAAYagAAAAENExeLqnUFx8vvtOfaQ8TKmQoeUqE4bA8x+LEA9pqrJeQlXDjt2UXtB7ewPDZ/vqKw==", "1d250a64-9a2f-43fd-99fb-893fd44f04b1" });
        }
    }
}
