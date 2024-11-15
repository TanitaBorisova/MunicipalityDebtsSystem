using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFKToMunicipalityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_EBKs_DataEbkId",
                schema: "mundebt",
                table: "Debts");

            migrationBuilder.DropTable(
                name: "EBKs",
                schema: "nomenclatures");

            migrationBuilder.DropIndex(
                name: "IX_Debts_DataEbkId",
                schema: "mundebt",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "DataEbkId",
                schema: "mundebt",
                table: "Debts");

            migrationBuilder.AddColumn<int>(
                name: "MunicipalityId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Identifier of Municipality");

            migrationBuilder.AddColumn<int>(
                name: "MunicipalityId",
                schema: "mundebt",
                table: "Covers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Identifier of Municipality");

            migrationBuilder.CreateTable(
                name: "Draws",
                schema: "mundebt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the draw")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebtId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the debt"),
                    DrawParentId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the parent draw - populated for real draw"),
                    DrawDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the draw"),
                    DrawAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of the draw"),
                    OperationTypeId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the debt"),
                    MunicipalityId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of Municipality"),
                    UserCreated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "User created the draw"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date creation of the draw"),
                    UserModified = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "User modified the draw"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of modification of the draw"),
                    UserDeleted = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "User marked the draw as deleted"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of deletion of the draw"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Shows if the draw is marked as deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Draws_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalSchema: "nomenclatures",
                        principalTable: "Municipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Table for storing draws of the debt");

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "mundebt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the payment")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebtId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the debt"),
                    PaymentParentId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the parent payment - populated for real payment"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the payment"),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of the payment"),
                    InterestAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Interest amount of the payment"),
                    OperateTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Tax amount of the payment"),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Interest rate of the payment"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Comment for the payment"),
                    OperationTypeId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the debt"),
                    MunicipalityId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of Municipality"),
                    UserCreated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "User created the payment"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date creation of the payment"),
                    UserModified = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "User modified the payment"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of modification of the payment"),
                    UserDeleted = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "User marked the payment as deleted"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of deletion of the payment"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Shows if the payment is marked as deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalSchema: "nomenclatures",
                        principalTable: "Municipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Table for storing payments of the debt");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_MunicipalityId",
                schema: "mundebt",
                table: "Debts",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Covers_MunicipalityId",
                schema: "mundebt",
                table: "Covers",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Draws_MunicipalityId",
                schema: "mundebt",
                table: "Draws",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MunicipalityId",
                schema: "mundebt",
                table: "Payments",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_Municipalities_MunicipalityId",
                schema: "mundebt",
                table: "Covers",
                column: "MunicipalityId",
                principalSchema: "nomenclatures",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_Municipalities_MunicipalityId",
                schema: "mundebt",
                table: "Debts",
                column: "MunicipalityId",
                principalSchema: "nomenclatures",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Covers_Municipalities_MunicipalityId",
                schema: "mundebt",
                table: "Covers");

            migrationBuilder.DropForeignKey(
                name: "FK_Debts_Municipalities_MunicipalityId",
                schema: "mundebt",
                table: "Debts");

            migrationBuilder.DropTable(
                name: "Draws",
                schema: "mundebt");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "mundebt");

            migrationBuilder.DropIndex(
                name: "IX_Debts_MunicipalityId",
                schema: "mundebt",
                table: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_Covers_MunicipalityId",
                schema: "mundebt",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "MunicipalityId",
                schema: "mundebt",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "MunicipalityId",
                schema: "mundebt",
                table: "Covers");

            migrationBuilder.AddColumn<int>(
                name: "DataEbkId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Identifier of EBK code");

            migrationBuilder.CreateTable(
                name: "EBKs",
                schema: "nomenclatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EBKs", x => x.Id);
                },
                comment: "Table for all municipalities in BG with their EBK codes");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_DataEbkId",
                schema: "mundebt",
                table: "Debts",
                column: "DataEbkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_EBKs_DataEbkId",
                schema: "mundebt",
                table: "Debts",
                column: "DataEbkId",
                principalSchema: "nomenclatures",
                principalTable: "EBKs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
