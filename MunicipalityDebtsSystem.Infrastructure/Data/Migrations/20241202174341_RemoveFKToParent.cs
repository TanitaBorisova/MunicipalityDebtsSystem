using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFKToParent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "8efb259f-fec9-4b0c-a972-8c26ec298688", "AQAAAAIAAYagAAAAEM7VwG0Dn8selgyhn3oR+BxDzAhB4MrnMt9btUFqrxlWXfXTtu/69gB0GAZT3uZEkQ==", "fa8122a4-ddbc-4424-83c1-682edefe6d0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89c5ae5f-c288-4ad6-a82b-c5eba38fa5c4", "AQAAAAIAAYagAAAAEDMe6FOc3acr1xgfTsyrj5SVqqUqdompABP3srSEzhdvv+0GMaXbArHv3yZhwcEzDg==", "081bfbbd-da44-4c80-b6c9-0786bbfd5c1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b03e4730-05f3-4d87-8ad8-2ce357100b3e", "AQAAAAIAAYagAAAAEK+imOEOZL/Ty22kI4/xLrEmK2Z8gwdOfFqJ6heIMkWGF2BBABmaNnjyTb9FFQOkfA==", "fae73737-71d2-4ebf-8844-cb2b31cdfc2d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
