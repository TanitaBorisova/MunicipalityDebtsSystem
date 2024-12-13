using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAnddateToCoverEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                schema: "mundebt",
                table: "Covers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date creation of the cover");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                schema: "mundebt",
                table: "Covers",
                type: "datetime2",
                nullable: true,
                comment: "Date of deletion of the cover");

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                schema: "mundebt",
                table: "Covers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                comment: "User created the cover");

            migrationBuilder.AddColumn<string>(
                name: "UserDeleted",
                schema: "mundebt",
                table: "Covers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                comment: "User marked the cover as deleted");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67736c7e-4885-4c1a-800d-96d10a587d9b", "AQAAAAIAAYagAAAAELtjdBqZ8nUJjvKo+yfC6szsLOZO2rVw3Eddz5yJ1eZoi8ZV0kfPIdh0/dABswN5ZQ==", "0470e52e-9901-41fe-ba4a-304462a22130" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c327dd1d-482e-4d5e-b554-bdb29555d56d", "AQAAAAIAAYagAAAAEPpsXAt/+s7jfI0jR7N86GeCRWPT9vUEioIyDf+SINLG/jMpNGQ+lvmFYg3IyCI9kg==", "4bc5c540-3f51-456d-abdf-fde8973e5957" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7adb7e4b-7f1c-49ee-ac70-9b6728d31695", "AQAAAAIAAYagAAAAENwUFsMMDDiOJIMFWnRGmF6ugPoW92uy3z14Ww1U5Uj+BTAoClsAzw7FNLTeb5ndAQ==", "820ba0d8-7c4e-4160-8783-521a57468f7c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                schema: "mundebt",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                schema: "mundebt",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                schema: "mundebt",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "UserDeleted",
                schema: "mundebt",
                table: "Covers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7aadaec-60f4-4a5a-be71-0c17519f2c4c", "AQAAAAIAAYagAAAAEGI9KZJ0GBU5I4Xx5RxSLrAZ2svpMR/oSoQRi+WvQBgvzc3CWRkNYtXJNZyUXJ6iYw==", "99ce82d5-6c6f-488b-8097-dbf0cd9dcd27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff5532bc-68d2-4e75-bad1-558436f77276", "AQAAAAIAAYagAAAAEPnptkQ6pLVsyferEJsN+foIhdQrRhUHKk8Q//ySb4GNm+eYxACr1uj2axx5C//TUA==", "17d2ab7d-6ddd-4275-9719-efffb100bdb9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43f7db23-df6e-4d06-b644-b123688a0ed6", "AQAAAAIAAYagAAAAEGIfqeNcWYA9xWjTPYCMlCIuQ8iZXiyfOj9VLb4pEYFAJsBc8LdvalGWi+ZNFkt0oQ==", "8db69507-00b9-466d-8b2c-68793f7129b5" });
        }
    }
}
