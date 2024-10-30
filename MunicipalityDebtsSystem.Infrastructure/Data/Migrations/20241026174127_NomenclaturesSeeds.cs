using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class NomenclaturesSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "nomenclatures",
                table: "CreditsStatusesTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Непотвърден" },
                    { 2, false, "Потвърден" },
                    { 3, false, "Приключен" },
                    { 4, false, "Предоговорен" },
                    { 5, false, "Предоговорен/Приключен" }
                });

            migrationBuilder.InsertData(
                schema: "nomenclatures",
                table: "CreditsTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Изискуема общинска гаранция" },
                    { 2, false, "Безлихвени заеми, отпуснати по реда на ЗПФ" },
                    { 3, false, "Търговски кредити" },
                    { 4, false, "Финансов лизинг" },
                    { 5, false, "Останали форми на дълг" },
                    { 6, false, "Възмездно финансиране по чл.103, ал.3 от ЗПФ" },
                    { 7, false, "Договор за общински заем" },
                    { 8, false, "Общинските предприятия по чл. 52 от ЗОС" },
                    { 9, false, "Безлихвени заеми от ЦБ по чл.43 ал.1 от ЗУДБ" },
                    { 10, false, "Търговски кредити над две години" },
                    { 11, false, "Финансов лизинг над две години" }
                });

            migrationBuilder.InsertData(
                schema: "nomenclatures",
                table: "DebtsTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Краткосрочен" },
                    { 2, false, "Дългосрочен" }
                });

            migrationBuilder.InsertData(
                schema: "nomenclatures",
                table: "InterestsTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "С отстъпка" },
                    { 2, false, "Фиксиран" },
                    { 3, false, "Плаващ" },
                    { 4, false, "Нулев" }
                });

            migrationBuilder.InsertData(
                schema: "nomenclatures",
                table: "DebtsPurposesTypes",
                columns: new[] { "Id", "DebtTypeId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 2, false, "Инвестиционни проекти" },
                    { 2, 2, false, "Рефинансиране на съществуващ дълг" },
                    { 3, 2, false, "Форсмажорни обстоятелства" },
                    { 4, 2, false, "Изискуеми общински гаранции" },
                    { 5, 1, false, "Временен недостиг на средства" },
                    { 6, 1, false, "Капиталови разходи" },
                    { 7, 2, false, "Неотложни разходи" },
                    { 8, 2, false, "Закупуване на ДМА" },
                    { 9, 1, false, "Плащания по проекти, финансирани с ЕС" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsStatusesTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsStatusesTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsStatusesTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsStatusesTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsStatusesTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "CreditsTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "DebtsPurposesTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "DebtsPurposesTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "DebtsPurposesTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "DebtsPurposesTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "DebtsPurposesTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "DebtsPurposesTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "DebtsPurposesTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "DebtsPurposesTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "DebtsPurposesTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "InterestsTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "InterestsTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "InterestsTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "InterestsTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "DebtsTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "nomenclatures",
                table: "DebtsTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
