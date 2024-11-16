using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyAddedToCurrencyRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CurrenciesRates_CurrencyId",
                schema: "mundebt",
                table: "CurrenciesRates",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrenciesRates_Currencies_CurrencyId",
                schema: "mundebt",
                table: "CurrenciesRates",
                column: "CurrencyId",
                principalSchema: "nomenclatures",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrenciesRates_Currencies_CurrencyId",
                schema: "mundebt",
                table: "CurrenciesRates");

            migrationBuilder.DropIndex(
                name: "IX_CurrenciesRates_CurrencyId",
                schema: "mundebt",
                table: "CurrenciesRates");
        }
    }
}
