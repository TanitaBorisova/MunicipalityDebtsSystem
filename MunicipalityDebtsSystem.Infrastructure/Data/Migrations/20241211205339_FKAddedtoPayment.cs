using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class FKAddedtoPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DebtId",
                schema: "mundebt",
                table: "Payments",
                column: "DebtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Debts_DebtId",
                schema: "mundebt",
                table: "Payments",
                column: "DebtId",
                principalSchema: "mundebt",
                principalTable: "Debts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Debts_DebtId",
                schema: "mundebt",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_DebtId",
                schema: "mundebt",
                table: "Payments");

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
    }
}
