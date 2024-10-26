using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Nomenclatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "nomenclatures");

            migrationBuilder.CreateTable(
                name: "CreditorType",
                schema: "nomenclatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditorType", x => x.Id);
                },
                comment: "Table for creditor's types");

            migrationBuilder.CreateTable(
                name: "CreditStatusType",
                schema: "nomenclatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditStatusType", x => x.Id);
                },
                comment: "Table for statuses of the credit");

            migrationBuilder.CreateTable(
                name: "CreditsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DebtType",
                schema: "nomenclatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtType", x => x.Id);
                },
                comment: "Table for all types of debt");

            migrationBuilder.CreateTable(
                name: "InterestType",
                schema: "nomenclatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestType", x => x.Id);
                },
                comment: "Table for all types of interest");

            migrationBuilder.CreateTable(
                name: "DebtPurposeType",
                schema: "nomenclatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebtTypeId = table.Column<int>(type: "int", nullable: false, comment: "Identificator of debt type"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtPurposeType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtPurposeType_DebtType_DebtTypeId",
                        column: x => x.DebtTypeId,
                        principalSchema: "nomenclatures",
                        principalTable: "DebtType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Table for purpose of the debt");

            migrationBuilder.CreateIndex(
                name: "IX_DebtPurposeType_DebtTypeId",
                schema: "nomenclatures",
                table: "DebtPurposeType",
                column: "DebtTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditorType",
                schema: "nomenclatures");

            migrationBuilder.DropTable(
                name: "CreditStatusType",
                schema: "nomenclatures");

            migrationBuilder.DropTable(
                name: "CreditsTypes");

            migrationBuilder.DropTable(
                name: "DebtPurposeType",
                schema: "nomenclatures");

            migrationBuilder.DropTable(
                name: "InterestType",
                schema: "nomenclatures");

            migrationBuilder.DropTable(
                name: "DebtType",
                schema: "nomenclatures");
        }
    }
}
