using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class CommentsInDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserModified",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User modified the debt",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserDeleted",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User marked the debt as deleted",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCreated",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(max)",
                nullable: false,
                comment: "User created the debt",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ResolutionNumber",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Resolution number of the debt",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNegotiated",
                schema: "mundebt",
                table: "Debts",
                type: "bit",
                nullable: false,
                comment: "Shows whether the debt is negotiated",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "mundebt",
                table: "Debts",
                type: "bit",
                nullable: false,
                comment: "Shows if the debt is marked as deleted",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "InterestTypeId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                comment: "Identifier of interest type",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestRate",
                schema: "mundebt",
                table: "Debts",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Interest rate",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "DebtTermTypeId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                comment: "Identifier of debt type",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DebtPurposeTypeId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                comment: "Identifier of debt purpose type",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DebtParentId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                comment: "Identifier of the parent debt when current debt is created with negotiation",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DebtNumber",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Number of the debt",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "DebtCurrency",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                comment: "Currency of the debt",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "DebtAmountOriginalCcy",
                schema: "mundebt",
                table: "Debts",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Amount of the debt in original currency",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DebtAmountLocalCcy",
                schema: "mundebt",
                table: "Debts",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Amount of the debt in local currency",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRealFinish",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: false,
                comment: "Date of real finish of the debt",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateNegotiate",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: false,
                comment: "Date of negotiation of the debt",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: true,
                comment: "Date of modification of the debt",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: true,
                comment: "Date of deletion of the debt",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: false,
                comment: "Date creation of the debt",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateContractFinish",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: false,
                comment: "End date of the debt",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBook",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: false,
                comment: "Start date of the debt",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "DataEbkId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                comment: "Identifier of EBK code",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreditorTypeId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                comment: "Identifier of creditor type",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreditTypeId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                comment: "Identifier of credit type",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreditStatusId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                comment: "Identifier of status of the credit",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                comment: "Identifier ot the debt",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "DebtId",
                schema: "mundebt",
                table: "Covers",
                type: "int",
                nullable: false,
                comment: "Identifier of the debt",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CoverTypeId",
                schema: "mundebt",
                table: "Covers",
                type: "int",
                nullable: false,
                comment: "Identifier of the cover type",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CoverDescription",
                schema: "mundebt",
                table: "Covers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Description of the cover",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CoverAmount",
                schema: "mundebt",
                table: "Covers",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Amount of the cover",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "mundebt",
                table: "Covers",
                type: "int",
                nullable: false,
                comment: "Identifier of the cover",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserModified",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User modified the debt");

            migrationBuilder.AlterColumn<string>(
                name: "UserDeleted",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User marked the debt as deleted");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreated",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "User created the debt");

            migrationBuilder.AlterColumn<string>(
                name: "ResolutionNumber",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Resolution number of the debt");

            migrationBuilder.AlterColumn<bool>(
                name: "IsNegotiated",
                schema: "mundebt",
                table: "Debts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Shows whether the debt is negotiated");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "mundebt",
                table: "Debts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Shows if the debt is marked as deleted");

            migrationBuilder.AlterColumn<int>(
                name: "InterestTypeId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of interest type");

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestRate",
                schema: "mundebt",
                table: "Debts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Interest rate");

            migrationBuilder.AlterColumn<int>(
                name: "DebtTermTypeId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of debt type");

            migrationBuilder.AlterColumn<int>(
                name: "DebtPurposeTypeId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of debt purpose type");

            migrationBuilder.AlterColumn<int>(
                name: "DebtParentId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of the parent debt when current debt is created with negotiation");

            migrationBuilder.AlterColumn<string>(
                name: "DebtNumber",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Number of the debt");

            migrationBuilder.AlterColumn<string>(
                name: "DebtCurrency",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldComment: "Currency of the debt");

            migrationBuilder.AlterColumn<decimal>(
                name: "DebtAmountOriginalCcy",
                schema: "mundebt",
                table: "Debts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Amount of the debt in original currency");

            migrationBuilder.AlterColumn<decimal>(
                name: "DebtAmountLocalCcy",
                schema: "mundebt",
                table: "Debts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Amount of the debt in local currency");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRealFinish",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date of real finish of the debt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateNegotiate",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date of negotiation of the debt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date of modification of the debt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date of deletion of the debt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date creation of the debt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateContractFinish",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "End date of the debt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBook",
                schema: "mundebt",
                table: "Debts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Start date of the debt");

            migrationBuilder.AlterColumn<int>(
                name: "DataEbkId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of EBK code");

            migrationBuilder.AlterColumn<int>(
                name: "CreditorTypeId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of creditor type");

            migrationBuilder.AlterColumn<int>(
                name: "CreditTypeId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of credit type");

            migrationBuilder.AlterColumn<int>(
                name: "CreditStatusId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of status of the credit");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier ot the debt")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "DebtId",
                schema: "mundebt",
                table: "Covers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of the debt");

            migrationBuilder.AlterColumn<int>(
                name: "CoverTypeId",
                schema: "mundebt",
                table: "Covers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of the cover type");

            migrationBuilder.AlterColumn<string>(
                name: "CoverDescription",
                schema: "mundebt",
                table: "Covers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Description of the cover");

            migrationBuilder.AlterColumn<decimal>(
                name: "CoverAmount",
                schema: "mundebt",
                table: "Covers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Amount of the cover");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "mundebt",
                table: "Covers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of the cover")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
