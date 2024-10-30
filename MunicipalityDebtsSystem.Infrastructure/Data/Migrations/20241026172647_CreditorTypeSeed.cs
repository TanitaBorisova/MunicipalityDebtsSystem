using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreditorTypeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "nomenclatures",
                table: "CreditorsTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Правителство" },
                    { 2, false, "МФ" },
                    { 3, false, "Кредитна институция - банка" },
                    { 4, false, "Финансова институция" },
                    { 5, false, "Община" },
                    { 6, false, "Българска банка за развитие АД" },
                    { 7, false, "Други" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditorsTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditorsTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditorsTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditorsTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditorsTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditorsTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditorsTypes",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
