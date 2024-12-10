using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsUnlockAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUnlock",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Shows whether the period is unlocked");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6528c61e-71d3-4146-904d-ed45a89f8fca", "AQAAAAIAAYagAAAAEB2u2GtPHyuawLDZABICpohQl8gH3GERGadVy9iTk90NHORuIruYZq1/Cz5oSK+WgQ==", "bfb82d34-6fad-473b-be2d-75e6b56e8ac1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "187af0d3-80f0-4920-8b5a-dbdceea3fbd9", "AQAAAAIAAYagAAAAEIrYIBqoAO7pDBva9gcxxmRNZ9yFj9ll8Jxw22seu1RJIIUDw0lta2g6j8OAPvd5Mw==", "83559cad-f395-4ab2-8b1c-d418119acf2d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04d24598-198b-46fe-9af8-a1121e918bcf", "AQAAAAIAAYagAAAAEFphZgDfze8eWSjYRzpzY1W0Ju7X1NErp/Ec6wpLQt58g2ibW6KzrU88w+jzp12muw==", "48a23a8c-ce9b-4952-9cdd-8c10d788f614" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUnlock",
                schema: "mundebt",
                table: "PeriodsLists");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8be9ddc2-3084-4152-809d-94ac0c27cafc", "AQAAAAIAAYagAAAAEKkFdl4xEAtdywZE3FKRadOBT9AVFX5jNBrOJHLYIBZHMMGbty7Ht2p9/W2P7ae79g==", "149a5b72-3185-4c39-89f9-8a18c0ff7922" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d03f5707-aa3f-4fe0-9a0c-25333247685b", "AQAAAAIAAYagAAAAEBRwHtyXj5+LOBeAfKXy6kyOcPdynXXIbpDXEl+GRX/bf7xm951OUL8cTInB3+1H+A==", "566d4b6c-7a93-438b-beed-1cab340739b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b788771-f2f2-492a-8595-cedc170b3537", "AQAAAAIAAYagAAAAEOnbq4ExBg2K7KncQQ83W6bBViofM2W7f25Y60T51edXQ9EqB57Ey8lkv7vNiDMLiw==", "3fdb40b0-bc66-4d1f-badd-2259bc538bff" });
        }
    }
}
