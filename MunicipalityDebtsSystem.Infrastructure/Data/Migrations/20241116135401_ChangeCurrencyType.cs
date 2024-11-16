using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCurrencyType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebtCurrency",
                schema: "mundebt",
                table: "Debts");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Currency of the debt");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_CurrencyId",
                schema: "mundebt",
                table: "Debts",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_Currencies_CurrencyId",
                schema: "mundebt",
                table: "Debts",
                column: "CurrencyId",
                principalSchema: "nomenclatures",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_Currencies_CurrencyId",
                schema: "mundebt",
                table: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_Debts_CurrencyId",
                schema: "mundebt",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                schema: "mundebt",
                table: "Debts");

            migrationBuilder.AddColumn<string>(
                name: "DebtCurrency",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                comment: "Currency of the debt");
        }
    }
}
