using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalFieldInUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserModified",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "User modified the debt",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User modified the debt");

            migrationBuilder.AlterColumn<string>(
                name: "UserDeleted",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "User marked the debt as deleted",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User marked the debt as deleted");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreated",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "User created the debt",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "User created the debt");
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
                comment: "User modified the debt",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "User modified the debt");

            migrationBuilder.AlterColumn<string>(
                name: "UserDeleted",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User marked the debt as deleted",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "User marked the debt as deleted");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreated",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(max)",
                nullable: false,
                comment: "User created the debt",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "User created the debt");
        }
    }
}
