using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PeriodList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeriodsLists",
                schema: "mundebt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the period")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Starting date of the period"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Ending date of the period"),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Month of the period like string"),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Year of the period like string"),
                    MonthInt = table.Column<int>(type: "int", nullable: false, comment: "Month of the period like integer"),
                    YearInt = table.Column<int>(type: "int", nullable: false, comment: "Year of the period like integer"),
                    MunicipalityId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of Municipality"),
                    UserNameUnlock = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User unlocked the period"),
                    DateUnlock = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date that period become unlocked"),
                    UserNameLock = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "User locked the period"),
                    DateLock = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "User locked the period"),
                    MunicipatilyId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of Municipality")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodsLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodsLists_Municipalities_MunicipatilyId",
                        column: x => x.MunicipatilyId,
                        principalSchema: "nomenclatures",
                        principalTable: "Municipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Table for storing allowed periods for storing data");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "697d9bd4-5f2b-4028-9c87-8f10fabdbcd0", "AQAAAAIAAYagAAAAEPfQVnxx39MIwiqhFJRF0JKHdQj247GfrqDYGo0X+ueyaEWqMW13MzqZyjuXHjTx4w==", "a339fad8-3d47-4dd2-9d78-6813f43bcb91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c31740ee-5471-448a-aaa6-1f1393c54292", "AQAAAAIAAYagAAAAEBkxNdaqGEMWYiH8cxSjUMPNQPuae0WIGZseOVEBvlQnVy96uNLpUs6kkEuAHiPJPA==", "3c277d8f-f572-4174-945f-f642aeafbb80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d12f4301-f324-4725-ba01-33633e0900ea", "AQAAAAIAAYagAAAAENExeLqnUFx8vvtOfaQ8TKmQoeUqE4bA8x+LEA9pqrJeQlXDjt2UXtB7ewPDZ/vqKw==", "1d250a64-9a2f-43fd-99fb-893fd44f04b1" });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodsLists_MunicipatilyId",
                schema: "mundebt",
                table: "PeriodsLists",
                column: "MunicipatilyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodsLists",
                schema: "mundebt");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bce51dab-eb06-47a8-b551-eb59da5b63b7", "AQAAAAIAAYagAAAAEMoLzX4gVv1YdLLMkc8Fi/3oHlxQPWd+eitwtohQQ4lsBbq+xSaLGSr+hsrp/SxQqQ==", "a5810f73-be18-4298-b8d2-6b01164962bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46ff8797-772a-43bc-9705-b7eef3bfb123", "AQAAAAIAAYagAAAAEOj1wMYKumH4p1kQIxXoGD4Ks5YxAQSQwLSxE21ljoBMOXra1Zzjsr3ay7ll/QaE7g==", "6994ad22-04c8-401f-bbd3-0e3873c5cd53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58a4a137-924b-4c3d-90a5-c8cc94ff1a6b", "AQAAAAIAAYagAAAAEEZFBs9w724IqUjivV1KDqUASsF2KSMxxVa7YoZXEoAElA+7WmsLMxdiOYnNcwZK1w==", "cb142afe-0942-445d-a731-e10ae5b5219d" });
        }
    }
}
