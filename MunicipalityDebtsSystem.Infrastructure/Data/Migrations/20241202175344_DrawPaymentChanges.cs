using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class DrawPaymentChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PaymentParentId",
                schema: "mundebt",
                table: "Payments",
                type: "int",
                nullable: true,
                comment: "Identifier of the parent payment - populated for real payment",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of the parent payment - populated for real payment");

            migrationBuilder.AlterColumn<int>(
                name: "DrawParentId",
                schema: "mundebt",
                table: "Draws",
                type: "int",
                nullable: true,
                comment: "Identifier of the parent draw - populated for real draw",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of the parent draw - populated for real draw");

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

            migrationBuilder.AlterColumn<int>(
                name: "PaymentParentId",
                schema: "mundebt",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Identifier of the parent payment - populated for real payment",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Identifier of the parent payment - populated for real payment");

            migrationBuilder.AlterColumn<int>(
                name: "DrawParentId",
                schema: "mundebt",
                table: "Draws",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Identifier of the parent draw - populated for real draw",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Identifier of the parent draw - populated for real draw");

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
    }
}
