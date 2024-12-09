using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMaxLengthPeriodList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "YearName",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "Year of the period like string",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldComment: "Year of the period like string");

            migrationBuilder.AlterColumn<string>(
                name: "MonthName",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Month of the period like string",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "Month of the period like string");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0381343f-fbad-4eb9-9285-58c595d71a9d", "AQAAAAIAAYagAAAAEBsGvcd9GP39KENFml8O8t7TeGPh8Vlp6Vb/4zEtZ5zd1oA3p3sVxVp76FmKSu5oRA==", "a2e5e722-73e6-428e-89a2-7b4de3d6f945" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "298aad41-7402-4afc-b9d1-cb68b84e1672", "AQAAAAIAAYagAAAAELx78/hB/cZUKSPkCpx138bzv4HXCZfnfDEe2WS4BSK6AH5EewmGVtYUc+0o2+0Adg==", "884afb47-eb05-4c0e-8a45-6a820dc85910" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e69b97f-2c08-4392-b738-2678fb92391d", "AQAAAAIAAYagAAAAENeDjm3ITKkMeMwinJXQW5EPtA5kU+tZLBHXwV9oBuR9n4+IRSs21N4+2Ud57A4/cg==", "43e43330-2ee3-4c65-b129-b9e8288050a3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "YearName",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                comment: "Year of the period like string",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "Year of the period like string");

            migrationBuilder.AlterColumn<string>(
                name: "MonthName",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "Month of the period like string",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Month of the period like string");

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
    }
}
