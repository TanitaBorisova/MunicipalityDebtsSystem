using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsFinishedAddedToDraws : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                schema: "mundebt",
                table: "Draws",
                type: "bit",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                schema: "mundebt",
                table: "Draws");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af3356f9-129c-4927-a8ff-aea6954ca661", "AQAAAAIAAYagAAAAEEyU9xlfSPpf5R4MxUOIfBd86iTQltrpr943WXua1sJkKTcsk9+Cdzmww8ItchPhwg==", "184ca9cc-81ce-42dd-bbb7-2b19bd216012" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "456ea676-34cc-4a57-b8b3-03ab91ea7ad9", "AQAAAAIAAYagAAAAEEV8nUpsa1BgWIFCSruGWPWDBZb70XbDYs+FdxCBroRs5RdOYAu7mQsAyKdr/Y17Cg==", "2d3b95a4-b7b0-4f32-814f-ae21ee8dbcce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00295604-9ab7-4b6f-aedb-8b4c18ba9743", "AQAAAAIAAYagAAAAEP7sAO16L1n3oKLtwV0yLrkcorqDYz4mjBOrEAwVv+hv3ljrV+EHxenkTfDl6vsxBA==", "c57e8cc8-f673-499e-a25f-1027a2796fc7" });
        }
    }
}
