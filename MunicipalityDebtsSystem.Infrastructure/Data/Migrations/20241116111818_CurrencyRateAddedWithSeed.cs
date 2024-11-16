using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class CurrencyRateAddedWithSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrenciesRates",
                schema: "mundebt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier ot the rate")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the currency"),
                    RateToBGN = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "Rate from foreign currency to local - BGN"),
                    RateFromBGN = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "Rate from local - BGN to foreign currency")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrenciesRates", x => x.Id);
                },
                comment: "Table for currency rates");

            migrationBuilder.UpdateData(
                schema: "nomenclatures",
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CurrencyCode",
                value: "RON");

            migrationBuilder.InsertData(
                schema: "mundebt",
                table: "CurrenciesRates",
                columns: new[] { "Id", "CurrencyId", "RateFromBGN", "RateToBGN" },
                values: new object[,]
                {
                    { 1, 1, 1m, 1m },
                    { 2, 2, 0.5112m, 1.9558m },
                    { 3, 3, 0.7593m, 1.3164m },
                    { 4, 4, 0.4786m, 2.0893m },
                    { 5, 5, 0.4271m, 2.3413m },
                    { 6, 6, 83.2126m, 0.0120m },
                    { 7, 7, 2.5448m, 0.3928m },
                    { 8, 8, 0.5388m, 1.8552m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrenciesRates",
                schema: "mundebt");

            migrationBuilder.UpdateData(
                schema: "nomenclatures",
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CurrencyCode",
                value: "ROL");
        }
    }
}
