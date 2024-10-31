using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RestrictAndOperationTypeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mundebt");

            migrationBuilder.CreateTable(
                name: "CoversTypes",
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
                    table.PrimaryKey("PK_CoversTypes", x => x.Id);
                },
                comment: "Table for all types of covers");

            migrationBuilder.CreateTable(
                name: "EBKs",
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
                    table.PrimaryKey("PK_EBKs", x => x.Id);
                },
                comment: "Table for all municipalities in BG with their EBK codes");

            migrationBuilder.CreateTable(
                name: "OperationsTypes",
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
                    table.PrimaryKey("PK_OperationsTypes", x => x.Id);
                },
                comment: "Table for all types of operations");

            migrationBuilder.CreateTable(
                name: "Debts",
                schema: "mundebt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebtParentId = table.Column<int>(type: "int", nullable: false),
                    DebtNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ResolutionNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateBook = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateNegotiate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateContractFinish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRealFinish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DebtCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DebtAmountOriginalCcy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DebtAmountLocalCcy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditTypeId = table.Column<int>(type: "int", nullable: false),
                    CreditorTypeId = table.Column<int>(type: "int", nullable: false),
                    DebtTermTypeId = table.Column<int>(type: "int", nullable: false),
                    DebtPurposeTypeId = table.Column<int>(type: "int", nullable: false),
                    InterestTypeId = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditStatusId = table.Column<int>(type: "int", nullable: false),
                    DataEbkId = table.Column<int>(type: "int", nullable: false),
                    IsNegotiated = table.Column<bool>(type: "bit", nullable: false),
                    UserCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debts_CreditorsTypes_CreditorTypeId",
                        column: x => x.CreditorTypeId,
                        principalSchema: "nomenclatures",
                        principalTable: "CreditorsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Debts_CreditsStatusesTypes_CreditStatusId",
                        column: x => x.CreditStatusId,
                        principalSchema: "nomenclatures",
                        principalTable: "CreditsStatusesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Debts_CreditsTypes_CreditTypeId",
                        column: x => x.CreditTypeId,
                        principalSchema: "nomenclatures",
                        principalTable: "CreditsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Debts_DebtsPurposesTypes_DebtPurposeTypeId",
                        column: x => x.DebtPurposeTypeId,
                        principalSchema: "nomenclatures",
                        principalTable: "DebtsPurposesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Debts_DebtsTypes_DebtTermTypeId",
                        column: x => x.DebtTermTypeId,
                        principalSchema: "nomenclatures",
                        principalTable: "DebtsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Debts_EBKs_DataEbkId",
                        column: x => x.DataEbkId,
                        principalSchema: "nomenclatures",
                        principalTable: "EBKs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Debts_InterestsTypes_InterestTypeId",
                        column: x => x.InterestTypeId,
                        principalSchema: "nomenclatures",
                        principalTable: "InterestsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Table for storing municipalities debts");

            migrationBuilder.CreateTable(
                name: "Covers",
                schema: "mundebt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebtId = table.Column<int>(type: "int", nullable: false),
                    CoverTypeId = table.Column<int>(type: "int", nullable: false),
                    CoverAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoverDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Covers_CoversTypes_CoverTypeId",
                        column: x => x.CoverTypeId,
                        principalSchema: "nomenclatures",
                        principalTable: "CoversTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Covers_Debts_DebtId",
                        column: x => x.DebtId,
                        principalSchema: "mundebt",
                        principalTable: "Debts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Table for storing covers of the debts");

            migrationBuilder.InsertData(
                schema: "nomenclatures",
                table: "CoversTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Парични средства" },
                    { 2, false, "Непарични средства" }
                });

            migrationBuilder.InsertData(
                schema: "nomenclatures",
                table: "OperationsTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Плащане" },
                    { 2, false, "Планирано плащане" },
                    { 3, false, "Усвояване" },
                    { 4, false, "Прогнозно усвояване" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Covers_CoverTypeId",
                schema: "mundebt",
                table: "Covers",
                column: "CoverTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Covers_DebtId",
                schema: "mundebt",
                table: "Covers",
                column: "DebtId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_CreditorTypeId",
                schema: "mundebt",
                table: "Debts",
                column: "CreditorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_CreditStatusId",
                schema: "mundebt",
                table: "Debts",
                column: "CreditStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_CreditTypeId",
                schema: "mundebt",
                table: "Debts",
                column: "CreditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_DataEbkId",
                schema: "mundebt",
                table: "Debts",
                column: "DataEbkId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_DebtPurposeTypeId",
                schema: "mundebt",
                table: "Debts",
                column: "DebtPurposeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_DebtTermTypeId",
                schema: "mundebt",
                table: "Debts",
                column: "DebtTermTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_InterestTypeId",
                schema: "mundebt",
                table: "Debts",
                column: "InterestTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Covers",
                schema: "mundebt");

            migrationBuilder.DropTable(
                name: "OperationsTypes",
                schema: "nomenclatures");

            migrationBuilder.DropTable(
                name: "CoversTypes",
                schema: "nomenclatures");

            migrationBuilder.DropTable(
                name: "Debts",
                schema: "mundebt");

            migrationBuilder.DropTable(
                name: "EBKs",
                schema: "nomenclatures");
        }
    }
}
