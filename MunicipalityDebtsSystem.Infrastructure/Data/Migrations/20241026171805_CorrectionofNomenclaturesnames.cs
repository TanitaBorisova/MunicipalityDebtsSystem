using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionofNomenclaturesnames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtPurposeType_DebtType_DebtTypeId",
                schema: "nomenclatures",
                table: "DebtPurposeType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestType",
                schema: "nomenclatures",
                table: "InterestType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DebtType",
                schema: "nomenclatures",
                table: "DebtType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DebtPurposeType",
                schema: "nomenclatures",
                table: "DebtPurposeType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditStatusType",
                schema: "nomenclatures",
                table: "CreditStatusType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditorType",
                schema: "nomenclatures",
                table: "CreditorType");

            migrationBuilder.RenameTable(
                name: "CreditsTypes",
                newName: "CreditsTypes",
                newSchema: "nomenclatures");

            migrationBuilder.RenameTable(
                name: "InterestType",
                schema: "nomenclatures",
                newName: "InterestsTypes",
                newSchema: "nomenclatures");

            migrationBuilder.RenameTable(
                name: "DebtType",
                schema: "nomenclatures",
                newName: "DebtsTypes",
                newSchema: "nomenclatures");

            migrationBuilder.RenameTable(
                name: "DebtPurposeType",
                schema: "nomenclatures",
                newName: "DebtsPurposesTypes",
                newSchema: "nomenclatures");

            migrationBuilder.RenameTable(
                name: "CreditStatusType",
                schema: "nomenclatures",
                newName: "CreditsStatusesTypes",
                newSchema: "nomenclatures");

            migrationBuilder.RenameTable(
                name: "CreditorType",
                schema: "nomenclatures",
                newName: "CreditorsTypes",
                newSchema: "nomenclatures");

            migrationBuilder.RenameIndex(
                name: "IX_DebtPurposeType_DebtTypeId",
                schema: "nomenclatures",
                table: "DebtsPurposesTypes",
                newName: "IX_DebtsPurposesTypes_DebtTypeId");

            migrationBuilder.AlterTable(
                name: "CreditsTypes",
                schema: "nomenclatures",
                comment: "Table for types of the credit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestsTypes",
                schema: "nomenclatures",
                table: "InterestsTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DebtsTypes",
                schema: "nomenclatures",
                table: "DebtsTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DebtsPurposesTypes",
                schema: "nomenclatures",
                table: "DebtsPurposesTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditsStatusesTypes",
                schema: "nomenclatures",
                table: "CreditsStatusesTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditorsTypes",
                schema: "nomenclatures",
                table: "CreditorsTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtsPurposesTypes_DebtsTypes_DebtTypeId",
                schema: "nomenclatures",
                table: "DebtsPurposesTypes",
                column: "DebtTypeId",
                principalSchema: "nomenclatures",
                principalTable: "DebtsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtsPurposesTypes_DebtsTypes_DebtTypeId",
                schema: "nomenclatures",
                table: "DebtsPurposesTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestsTypes",
                schema: "nomenclatures",
                table: "InterestsTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DebtsTypes",
                schema: "nomenclatures",
                table: "DebtsTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DebtsPurposesTypes",
                schema: "nomenclatures",
                table: "DebtsPurposesTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditsStatusesTypes",
                schema: "nomenclatures",
                table: "CreditsStatusesTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditorsTypes",
                schema: "nomenclatures",
                table: "CreditorsTypes");

            migrationBuilder.RenameTable(
                name: "CreditsTypes",
                schema: "nomenclatures",
                newName: "CreditsTypes");

            migrationBuilder.RenameTable(
                name: "InterestsTypes",
                schema: "nomenclatures",
                newName: "InterestType",
                newSchema: "nomenclatures");

            migrationBuilder.RenameTable(
                name: "DebtsTypes",
                schema: "nomenclatures",
                newName: "DebtType",
                newSchema: "nomenclatures");

            migrationBuilder.RenameTable(
                name: "DebtsPurposesTypes",
                schema: "nomenclatures",
                newName: "DebtPurposeType",
                newSchema: "nomenclatures");

            migrationBuilder.RenameTable(
                name: "CreditsStatusesTypes",
                schema: "nomenclatures",
                newName: "CreditStatusType",
                newSchema: "nomenclatures");

            migrationBuilder.RenameTable(
                name: "CreditorsTypes",
                schema: "nomenclatures",
                newName: "CreditorType",
                newSchema: "nomenclatures");

            migrationBuilder.RenameIndex(
                name: "IX_DebtsPurposesTypes_DebtTypeId",
                schema: "nomenclatures",
                table: "DebtPurposeType",
                newName: "IX_DebtPurposeType_DebtTypeId");

            migrationBuilder.AlterTable(
                name: "CreditsTypes",
                oldComment: "Table for types of the credit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestType",
                schema: "nomenclatures",
                table: "InterestType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DebtType",
                schema: "nomenclatures",
                table: "DebtType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DebtPurposeType",
                schema: "nomenclatures",
                table: "DebtPurposeType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditStatusType",
                schema: "nomenclatures",
                table: "CreditStatusType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditorType",
                schema: "nomenclatures",
                table: "CreditorType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtPurposeType_DebtType_DebtTypeId",
                schema: "nomenclatures",
                table: "DebtPurposeType",
                column: "DebtTypeId",
                principalSchema: "nomenclatures",
                principalTable: "DebtType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
