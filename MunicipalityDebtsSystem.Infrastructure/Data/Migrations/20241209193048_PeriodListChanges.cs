using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PeriodListChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                schema: "mundebt",
                table: "PeriodsLists",
                newName: "YearName");

            migrationBuilder.RenameColumn(
                name: "Month",
                schema: "mundebt",
                table: "PeriodsLists",
                newName: "MonthName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5ab5972-6453-4f46-afa4-fc4548127b43", "AQAAAAIAAYagAAAAEAJtJB2+TA0pORQ12fwqPI+6D44O1IcQnSbe/hg1p52j7tls6UA1k0k6RLcj/AzKQA==", "d905b1f3-71c3-4822-b7dc-11dd58239a0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09483c8c-efd7-430c-9d59-c873bb732c76", "AQAAAAIAAYagAAAAECz454w6qHi9jJFxNb5/6hdY4lS1dklXnIVo3IkeKa/fhizcJ0sajOKqkQDNHP59bg==", "b65f11bd-4360-4e5a-b4ff-2b229670252a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25110fb5-3a86-4279-ac82-e38d5f7e194d", "AQAAAAIAAYagAAAAEB2M7a+x8kFv2N9jPpvPmfOdE3xbqS3hMiljZHW7W/KVDL0cfAHpFyFCxvDxnGriDA==", "afb83612-67a4-457d-81f6-570f46c0b73a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearName",
                schema: "mundebt",
                table: "PeriodsLists",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "MonthName",
                schema: "mundebt",
                table: "PeriodsLists",
                newName: "Month");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2d23fd4-8aa1-42dd-8045-3e73c730ea49", "AQAAAAIAAYagAAAAECk/dGD/2IJHlO5SWZOSYn7uSqv6n7drINj2T89WJg/UN3P29ng3oM+WmSA0LmC7VA==", "5cad7027-5df6-42c5-a97d-3d04977ff659" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f27ff6a7-92a7-4fd6-95c5-ed181a6ffd68", "AQAAAAIAAYagAAAAEHX3icjeUYgeRQs8VOrqd1q+ZJTXMR6IymPMI7mJxnAv+TnnUY+Qo3HRLOci1QByYQ==", "7b0b9889-4625-45ee-b5d4-5a2d3391ff50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59094914-bc7c-4633-bae7-659ae746a7b9", "AQAAAAIAAYagAAAAEPR6I/eISdXlRFKJFuri9ofOdgvEJwXj1i20AQ4UTJ1qv9iOI7TmRNh8WiGf391C9A==", "fb23bc9d-97fd-4b9c-b703-fc75ca303f53" });
        }
    }
}
