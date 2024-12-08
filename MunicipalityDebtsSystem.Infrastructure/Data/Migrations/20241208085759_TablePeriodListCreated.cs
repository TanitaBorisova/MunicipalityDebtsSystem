using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class TablePeriodListCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bd3045e-ebb9-4eac-ac0e-dd64a0ed8c58", "AQAAAAIAAYagAAAAEMpJmXhPUwOJ8eSwRF/qwepaoR5p2Y1S4js2gj47OaLK6SrplQEed0ipL2r2nEPv0w==", "d626bc3b-536a-41c8-b0cc-495488ea6f74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22bd592c-8475-4e6d-834a-90f0b177b7e6", "AQAAAAIAAYagAAAAEOcqBaTHDLHJjwJbuh8UcLyGAmYAWmzkoNQ2uHEGquPVERnx/0ZbF6V6NqqoqPtkQw==", "46b098cb-f669-4a2b-b46e-86064786ce37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5afd84ee-1df5-43f2-9944-a4db9ec21c53", "AQAAAAIAAYagAAAAEJJM1O7yeRSj85s2rI7IJffbLSpy29Nh4rqB2zH/0GaJ4vIjB1oYaEzOo7IeeXqUvw==", "bb139579-8005-478d-84dd-8a0aaa8e2271" });
        }
    }
}
