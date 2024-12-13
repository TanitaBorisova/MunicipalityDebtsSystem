using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PaymentCommentDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                schema: "mundebt",
                table: "Payments");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                schema: "mundebt",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Comment for the payment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afe61622-7805-4268-bc09-91b05682e652", "AQAAAAIAAYagAAAAEE2amaq/OLkm64hGyzjWrYpFc9xeezp8ri4d2Bix3hthLulC9mJ/M4Dk6tMO2Np7nA==", "d974579a-b32f-41a2-9881-7c3920fcea4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39ee2895-3e42-4f66-a258-160e2aa97dc0", "AQAAAAIAAYagAAAAEGl0J5znaOuy2ggDfIB/7qj7tNvhqEKs5gKYuxqoX66gsDja23ABnCmfN4TmR3V+Gg==", "0bcdbfc2-fe0f-49d6-b4da-ba0c1b974112" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d29e0e0c-f08a-43f8-a3bd-3596be0a9427", "AQAAAAIAAYagAAAAECAWYrkgfujaEq8REi8Qs16uEz2TU76oj68TPPnHsGr4NxexkPRo7tYm3vDsg4IaxQ==", "e7870c64-a4a3-4518-9c4f-ee7bdbcbea56" });
        }
    }
}
