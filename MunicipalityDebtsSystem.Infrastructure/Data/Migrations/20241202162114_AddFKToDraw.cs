using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFKToDraw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9768cd7d-c889-4c1c-bbac-bd3f26361a37", "AQAAAAIAAYagAAAAEKlofQyef3Xmd2O98Xz5FoNgu/qOkkid+da/I/nheKptQPXX+XAaLdkTD/IrP2Nopw==", "d3710067-81f9-4bfd-b142-0e1996cfb346" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbdaea76-1026-4791-aaf5-ca09f1c4a4e1", "AQAAAAIAAYagAAAAEJ2hEXFH+9zwYckD2NA0wzuCHiv9mTBMvxczbRevSbCJaZd050EYGr1/4urqOumpjw==", "5956b6ed-fb69-48d6-b213-f97c30e70b19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2da80fb4-51ab-4687-ab5b-94fb42f3c5ee", "AQAAAAIAAYagAAAAEApEANRY/VIEB+vL7WzThneEDy1gz2Mc9vkIrLmsAEPhyeVpy9vHLXt5ifta2HKNkw==", "29b8ff1d-8563-4d50-b4cf-0cde35421cec" });

            migrationBuilder.CreateIndex(
                name: "IX_Draws_DebtId",
                schema: "mundebt",
                table: "Draws",
                column: "DebtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Draws_Debts_DebtId",
                schema: "mundebt",
                table: "Draws",
                column: "DebtId",
                principalSchema: "mundebt",
                principalTable: "Debts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Draws_Debts_DebtId",
                schema: "mundebt",
                table: "Draws");

            migrationBuilder.DropIndex(
                name: "IX_Draws_DebtId",
                schema: "mundebt",
                table: "Draws");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1e34a72-8534-42c1-9819-101740a37f95", "AQAAAAIAAYagAAAAEEYaJ8J3PLLFcBecYXDBhcisJrs+uRmxfIJfEBEwLty65lACFd0x12wDJGjcpQjcmQ==", "3b1ed00a-c3b3-4b44-b3e4-915abfb3e0ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5d95dde-9bf9-4890-ac53-f5bbbf7a5f61", "AQAAAAIAAYagAAAAEArc7nIGcR9rqjXtlQXsNnG5t0CG9JmZrxxLHdJZ7P+x+2xXx5LXnqlUAZyWykbNOg==", "6e955c9c-a309-4343-b2ff-38ecfa5eca34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3abb334-e4e8-4050-a00d-6c0898e8f8f7", "AQAAAAIAAYagAAAAEA+0aDbI/oZYe4VudKgyEdkJqL2erExzxtszddW9XFSpQyS0GjLQhANOBE29Mjvryw==", "206ac2ca-e049-48a4-aa25-3164be07e5d3" });
        }
    }
}
