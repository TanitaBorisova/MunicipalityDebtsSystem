using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class DebtIdNotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bff07036-3b6b-4fe0-8e7e-3608bd1d3bd8", "AQAAAAIAAYagAAAAEBBwVbrE+lPi+dIBE1zIMBMNCKifOYqa3rNAoosLu+109mrrSftHS1Wk4pfr+qrerQ==", "698ec7dd-6566-4305-a08f-ebc5b7e87189" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a2ccbbb-61eb-4f7f-b810-c3eeff666fe0", "AQAAAAIAAYagAAAAEBIP03+0ekkhzaEYK86PUH18S23L+6Mh9wPwFP3ZzUZKNFIYqUxQoIiZspkkLmTTNQ==", "b73f3fd1-6444-4e56-be0c-0dac29c88a0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dfb9e4f-0b9b-4b05-b16a-477bdb87b550", "AQAAAAIAAYagAAAAEGNgL0vUcFyWsVDPlldouL22WJRCO96CFd8N/6OZVmsyQa9/eI6xRlz2F29VV7uZJA==", "bf2efe84-c8ab-45d5-8288-9b333b722512" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentParentId",
                schema: "mundebt",
                table: "Payments",
                column: "PaymentParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Payments_PaymentParentId",
                schema: "mundebt",
                table: "Payments",
                column: "PaymentParentId",
                principalSchema: "mundebt",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Payments_PaymentParentId",
                schema: "mundebt",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PaymentParentId",
                schema: "mundebt",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c55556b3-7b91-42e6-ad6a-2a6d1be831d3", "AQAAAAIAAYagAAAAEHN+6ik2YuJeQyW0hkZhZx3aXOobXAcuoj6ykGxt7gzHNjbqGtp6/hguk85T3vG67Q==", "9185be05-d0a4-4d03-a430-984435bafd29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00cdaf91-07f1-4671-976e-eb4dedc1b849", "AQAAAAIAAYagAAAAEENuYvFC2QPiYygsdPCWdCR5FSMpupQqhM0wLjYcTBHIBPmof7wi+ke7Bx7HJyWSuA==", "407f11de-3450-4e3b-9f2c-be008744a9ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37b3e359-6bef-4d5d-985a-75dc4c661664", "AQAAAAIAAYagAAAAEGm3pVISSHmVyaAcKRAuTOFlFpbE4ocezFq2ZtBkK0rmUdfZg06BcekNl2z6ljAASg==", "97d3d54a-52ab-4e3c-9860-6a1f10619105" });
        }
    }
}
