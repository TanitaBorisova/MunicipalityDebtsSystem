using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PeriodListUserUnlock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserNameUnlock",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(50)",
                maxLength: 50,
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
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "User locked the period",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldNullable: true,
                oldComment: "User locked the period");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8be9ddc2-3084-4152-809d-94ac0c27cafc", "AQAAAAIAAYagAAAAEKkFdl4xEAtdywZE3FKRadOBT9AVFX5jNBrOJHLYIBZHMMGbty7Ht2p9/W2P7ae79g==", "149a5b72-3185-4c39-89f9-8a18c0ff7922" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d03f5707-aa3f-4fe0-9a0c-25333247685b", "AQAAAAIAAYagAAAAEBRwHtyXj5+LOBeAfKXy6kyOcPdynXXIbpDXEl+GRX/bf7xm951OUL8cTInB3+1H+A==", "566d4b6c-7a93-438b-beed-1cab340739b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b788771-f2f2-492a-8595-cedc170b3537", "AQAAAAIAAYagAAAAEOnbq4ExBg2K7KncQQ83W6bBViofM2W7f25Y60T51edXQ9EqB57Ey8lkv7vNiDMLiw==", "3fdb40b0-bc66-4d1f-badd-2259bc538bff" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserNameUnlock",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                comment: "User unlocked the period",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
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
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "User locked the period");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1628c160-f17f-4ba2-aa59-67d2825faf77", "AQAAAAIAAYagAAAAEMsaEQdisZIexda1iZqBEnw8/z9ihZpD2O8cPFcQH5bkaLK6rbQTI9wBdxFlgoQj5A==", "d11f5913-39a3-4ff0-a031-e54dbbe8d887" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c8a9057-8c21-4cfa-8941-d310a8848a18", "AQAAAAIAAYagAAAAELV5dtZgZhlZUJggmhT5OoaW6NpI5FNZR/lBmXKEDw85/+dj/QdQv0HaoNpu1JFJdg==", "608d8907-bd39-4f99-9423-aba05bf9c4eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "242ad719-6a3b-44fd-a704-01ca71f8b9da", "AQAAAAIAAYagAAAAEB25+ydR9eQDHzfqMn3Gg09UPqD5FQxUbvhESKZgzDcA6X2EDG1lDpmgV02SvSlYow==", "971964bc-eb08-443d-8f38-dc1bf81477cd" });
        }
    }
}
