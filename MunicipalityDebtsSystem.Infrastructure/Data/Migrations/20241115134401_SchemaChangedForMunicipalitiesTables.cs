using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SchemaChangedForMunicipalitiesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "MunicipalsCenters",
                newName: "MunicipalsCenters",
                newSchema: "nomenclatures");

            migrationBuilder.RenameTable(
                name: "Municipalities",
                newName: "Municipalities",
                newSchema: "nomenclatures");

            migrationBuilder.AlterTable(
                name: "MunicipalsCenters",
                schema: "nomenclatures",
                comment: "Table for all regions in BG");

            migrationBuilder.AlterTable(
                name: "Municipalities",
                schema: "nomenclatures",
                comment: "Table for all municipalities in BG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "MunicipalsCenters",
                schema: "nomenclatures",
                newName: "MunicipalsCenters");

            migrationBuilder.RenameTable(
                name: "Municipalities",
                schema: "nomenclatures",
                newName: "Municipalities");

            migrationBuilder.AlterTable(
                name: "MunicipalsCenters",
                oldComment: "Table for all regions in BG");

            migrationBuilder.AlterTable(
                name: "Municipalities",
                oldComment: "Table for all municipalities in BG");
        }
    }
}
