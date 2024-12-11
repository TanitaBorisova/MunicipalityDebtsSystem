using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PaymentCommentNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                schema: "mundebt",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Comment for the payment",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Comment for the payment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2786c42-3340-4205-be9f-e82663349bdf", "AQAAAAIAAYagAAAAEMF82izaXleQQmt+HCexz5FeV9llR4Q0A00YJ0sN1+pMlOcxZ+Y7Zm6odEWKniMefw==", "eea41b25-e8de-4d7b-8353-11959db983e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93beadba-3115-4983-aa0c-da23a18d82a9", "AQAAAAIAAYagAAAAEPYCqNiKBgo1x1TFlT8O1pT/hbrG7MU8m8ep417+ezCFE+no0fj0S9qyCfUNJs3FZw==", "cc8efe24-1377-48c8-ad20-9011287fac5f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fda5d00-e6d0-4fed-9811-3bea78bf7d98", "AQAAAAIAAYagAAAAEIfMouYXipbSTEfsj8JZy6claotCHx+rSN0P/RTRsRhFLMkN88A9Uof2g3cN/frQRw==", "d88945bc-b0df-4b64-b3df-72e0e16e1cae" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                schema: "mundebt",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Comment for the payment",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Comment for the payment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6528c61e-71d3-4146-904d-ed45a89f8fca", "AQAAAAIAAYagAAAAEB2u2GtPHyuawLDZABICpohQl8gH3GERGadVy9iTk90NHORuIruYZq1/Cz5oSK+WgQ==", "bfb82d34-6fad-473b-be2d-75e6b56e8ac1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "187af0d3-80f0-4920-8b5a-dbdceea3fbd9", "AQAAAAIAAYagAAAAEIrYIBqoAO7pDBva9gcxxmRNZ9yFj9ll8Jxw22seu1RJIIUDw0lta2g6j8OAPvd5Mw==", "83559cad-f395-4ab2-8b1c-d418119acf2d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04d24598-198b-46fe-9af8-a1121e918bcf", "AQAAAAIAAYagAAAAEFphZgDfze8eWSjYRzpzY1W0Ju7X1NErp/Ec6wpLQt58g2ibW6KzrU88w+jzp12muw==", "48a23a8c-ce9b-4952-9cdd-8c10d788f614" });
        }
    }
}
