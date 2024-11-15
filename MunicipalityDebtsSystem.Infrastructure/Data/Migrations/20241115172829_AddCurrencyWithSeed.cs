using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrencyWithSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                schema: "nomenclatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                },
                comment: "Table for currency");

            migrationBuilder.InsertData(
                schema: "nomenclatures",
                table: "Currencies",
                columns: new[] { "Id", "CurrencyCode", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "BGN", false, "Български лев" },
                    { 2, "EUR", false, "Евро" },
                    { 3, "CAD", false, "Kанaдски долар" },
                    { 4, "CHF", false, "Швейцарски франк" },
                    { 5, "GBP", false, "Британски паунд" },
                    { 6, "JPY", false, "Японска йена" },
                    { 7, "ROL", false, "Румънска лея" },
                    { 8, "USD", false, "Американски долар" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "nomenclatures");
        }
    }
}
