using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DebtParentId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: true,
                comment: "Identifier of the parent debt when current debt is created with negotiation",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of the parent debt when current debt is created with negotiation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a43867d9-1532-47d4-a159-6846dff68d0a", "AQAAAAIAAYagAAAAEJgdin4EThv3CsqjNGUKtQQbSwu9wl6GVs14wIOY/19sRZJawD7MOALu4SiQNa4UjA==", "154f3763-21c8-4141-bb1f-6401e17a2407" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed568673-8b81-426f-8c49-ba6794a2f4c1", "AQAAAAIAAYagAAAAEOSNP5vKVybSaYidQNzo4RZH6bSqz/BWTl4odaCo0xkEd5WkPG23nCBz1MS0H3V7Fw==", "97da031c-a195-4ca8-932c-9ad706d23337" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf5e3710-b0cb-41ae-8415-12b4a3cd2281", "AQAAAAIAAYagAAAAEJaVe6Z2JhsRXFBiIf0f4093kaOy1CaqKav5jEFyo/pCiDA9CVtMbbtt5G6v2L6yLg==", "dcd2e269-2eec-4eb2-9f43-d0e9539fb738" });

            migrationBuilder.CreateIndex(
                name: "IX_Debts_DebtParentId",
                schema: "mundebt",
                table: "Debts",
                column: "DebtParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_Debts_DebtParentId",
                schema: "mundebt",
                table: "Debts",
                column: "DebtParentId",
                principalSchema: "mundebt",
                principalTable: "Debts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_Debts_DebtParentId",
                schema: "mundebt",
                table: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_Debts_DebtParentId",
                schema: "mundebt",
                table: "Debts");

            migrationBuilder.AlterColumn<int>(
                name: "DebtParentId",
                schema: "mundebt",
                table: "Debts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Identifier of the parent debt when current debt is created with negotiation",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Identifier of the parent debt when current debt is created with negotiation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abd7655a-340a-41ce-947f-15a6681ff185", "AQAAAAIAAYagAAAAEAiz+8ONb9i9Yfi6SOiTw52chiM80AV0oS7RhC9szB+CKa5d6NDrRIL4JZTUN5vnpw==", "eb88a680-0616-479f-a71c-b2317d0ab126" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b63f9c8d-6f2d-47ff-ac15-9cb8715cc9ce", "AQAAAAIAAYagAAAAEOrRqgn5d2DWsfc3nwEIUWjVPuOHX4bjSNxnVEQa+RnuxGv2ig0CaCWiKEcKIhozDw==", "6f06202e-325f-4fd8-8a2b-7a065378dbad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1e9510e-5075-4b57-9731-988e708f49af", "AQAAAAIAAYagAAAAEGeL8YMWJMaPt2VGEZhaKZmU0OzvAiijUb4rru8rc3DLf3T35Fu+N6iT0bgeDC8YzA==", "1afe33b6-a67c-470a-bcb1-dd7bf68db6b5" });
        }
    }
}
