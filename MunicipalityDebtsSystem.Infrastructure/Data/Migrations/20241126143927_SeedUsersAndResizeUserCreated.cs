using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersAndResizeUserCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserModified",
                schema: "mundebt",
                table: "Payments",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                comment: "User modified the payment",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "User modified the payment");

            migrationBuilder.AlterColumn<string>(
                name: "UserDeleted",
                schema: "mundebt",
                table: "Payments",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                comment: "User marked the payment as deleted",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "User marked the payment as deleted");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreated",
                schema: "mundebt",
                table: "Payments",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                comment: "User created the payment",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "User created the payment");

            migrationBuilder.AlterColumn<string>(
                name: "UserModified",
                schema: "mundebt",
                table: "Draws",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                comment: "User modified the draw",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "User modified the draw");

            migrationBuilder.AlterColumn<string>(
                name: "UserDeleted",
                schema: "mundebt",
                table: "Draws",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                comment: "User marked the draw as deleted",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "User marked the draw as deleted");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreated",
                schema: "mundebt",
                table: "Draws",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                comment: "User created the draw",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "User created the draw");

            migrationBuilder.AlterColumn<string>(
                name: "UserModified",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(450)",
                maxLength: 450,
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
                type: "nvarchar(450)",
                maxLength: 450,
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
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                comment: "User created the debt",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "User created the debt");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MunicipalityId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "22ad10a0-2f69-4735-bd2c-9e944cd80baf", 3, "1c834c3e-9d0d-489f-a045-c960fea4b4b3", "burgas_municipal@mail.bg", false, "Стоян", "Георгиев", false, null, 16, "burgas_municipal@mail.bg", "burgas_municipal@mail.bg", "AQAAAAIAAYagAAAAEJLmFAOZZAiMojHrzqDoQs+6RsLE/UWcBFemfGwvttiOEtk+Wp+IP1TunWBk5XhyqA==", null, false, "0e8e3802-21cb-4328-a64e-9c637244424a", false, "burgas_municipal@mail.bg" },
                    { "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3", 3, "16d70716-b79d-4c2d-a2db-3e52af407e93", "adminDebt@mail.bg", false, "Иван", "Петров", false, null, null, "admindebt@mail.bg", "admindebt@mail.com", "AQAAAAIAAYagAAAAEOYEfK3kDPbqvOgA6zGD4stYqd9GDyQgyvt3APsEjMQFvYV3sXBuVQ42UywqExQi8g==", null, false, "c2e5ba44-b4f3-478e-b419-82c9bf7fa5e5", false, "adminDebt@mail.bg" },
                    { "faf648ad-8f38-459d-909f-256f9a167a44", 3, "3ebe5fa5-1a48-4440-8b49-5d8cb90247ef", "VarnaMun@mail.com", false, "Георги", "Василев", false, null, 32, "varnamun@mail.com", "varnamun@mail.com", null, null, false, "d8d35cd8-38e1-4f71-b944-107b274786b3", false, "VarnaMun@mail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44");

            migrationBuilder.AlterColumn<string>(
                name: "UserModified",
                schema: "mundebt",
                table: "Payments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "User modified the payment",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true,
                oldComment: "User modified the payment");

            migrationBuilder.AlterColumn<string>(
                name: "UserDeleted",
                schema: "mundebt",
                table: "Payments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "User marked the payment as deleted",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true,
                oldComment: "User marked the payment as deleted");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreated",
                schema: "mundebt",
                table: "Payments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "User created the payment",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldComment: "User created the payment");

            migrationBuilder.AlterColumn<string>(
                name: "UserModified",
                schema: "mundebt",
                table: "Draws",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "User modified the draw",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true,
                oldComment: "User modified the draw");

            migrationBuilder.AlterColumn<string>(
                name: "UserDeleted",
                schema: "mundebt",
                table: "Draws",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "User marked the draw as deleted",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true,
                oldComment: "User marked the draw as deleted");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreated",
                schema: "mundebt",
                table: "Draws",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "User created the draw",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldComment: "User created the draw");

            migrationBuilder.AlterColumn<string>(
                name: "UserModified",
                schema: "mundebt",
                table: "Debts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "User modified the debt",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
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
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
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
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldComment: "User created the debt");
        }
    }
}
