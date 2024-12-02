using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class DrawIdFKDrawParentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f91834fb-42c9-4e55-861e-903985e95ff8", "AQAAAAIAAYagAAAAEK89KLQxiwkvZ+ayawy7PKdIA8WueBFs0wTh33BUN9wP4I60iNIcC+VSOfSfH2hKEw==", "e201de11-23b8-4915-a744-058747820f6a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0217c9df-3fc7-4b16-a4fe-559ce49433d3", "AQAAAAIAAYagAAAAED9KX8fQ7iXmdIyRxwPc6W80VV3U2DfkV3rBAjq7zOmZN7AzO4g5MGLfCr0ovtRS6A==", "0f23b276-7082-49c5-a881-dd42e96c332c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18caad3d-2ea0-4847-a510-c5cae1b3432e", "AQAAAAIAAYagAAAAEA99TPCTk3iPDiR9j5DOF7QTtwv5zbduD0XxwHE/1KVjBJd3DJvyKm3qPX/l/GU5Sw==", "c688eb06-9775-48ce-86b6-2331e6d9a929" });

            migrationBuilder.CreateIndex(
                name: "IX_Draws_DrawParentId",
                schema: "mundebt",
                table: "Draws",
                column: "DrawParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Draws_Draws_DrawParentId",
                schema: "mundebt",
                table: "Draws",
                column: "DrawParentId",
                principalSchema: "mundebt",
                principalTable: "Draws",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Draws_Draws_DrawParentId",
                schema: "mundebt",
                table: "Draws");

            migrationBuilder.DropIndex(
                name: "IX_Draws_DrawParentId",
                schema: "mundebt",
                table: "Draws");

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
        }
    }
}
