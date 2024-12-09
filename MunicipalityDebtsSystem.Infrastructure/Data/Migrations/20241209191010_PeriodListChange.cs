using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PeriodListChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeriodsLists_Municipalities_MunicipatilyId",
                schema: "mundebt",
                table: "PeriodsLists");

            migrationBuilder.DropIndex(
                name: "IX_PeriodsLists_MunicipatilyId",
                schema: "mundebt",
                table: "PeriodsLists");

            migrationBuilder.DropColumn(
                name: "MunicipatilyId",
                schema: "mundebt",
                table: "PeriodsLists");

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

            migrationBuilder.CreateIndex(
                name: "IX_PeriodsLists_MunicipalityId",
                schema: "mundebt",
                table: "PeriodsLists",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodsLists_Municipalities_MunicipalityId",
                schema: "mundebt",
                table: "PeriodsLists",
                column: "MunicipalityId",
                principalSchema: "nomenclatures",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeriodsLists_Municipalities_MunicipalityId",
                schema: "mundebt",
                table: "PeriodsLists");

            migrationBuilder.DropIndex(
                name: "IX_PeriodsLists_MunicipalityId",
                schema: "mundebt",
                table: "PeriodsLists");

            migrationBuilder.AddColumn<int>(
                name: "MunicipatilyId",
                schema: "mundebt",
                table: "PeriodsLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Identifier of Municipality");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68b75200-d6ca-46d4-9954-a0c083495f7d", "AQAAAAIAAYagAAAAEJ3eLvdHOKQJDyUFVHGTAnQWASCr6qH0JV5B2FGDyaKHmg+XIRAkv2M+6tLqtFuz8Q==", "2f0fccb5-9694-40e1-bac5-c0dd5a441bbb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f890d53c-9541-4dfa-a27e-438664986fb1", "AQAAAAIAAYagAAAAEPoMEkwlFeP64WewjwPp3SOlCPzIUGEiwmzHRCnOSnqvHvpsLMMY0uquKoONHwACQw==", "57bd9e73-943d-4482-a600-635a79872a4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "345501da-44a0-4f9d-a8be-b99b75ab8c27", "AQAAAAIAAYagAAAAEEgbe4WEjcPV3Ti/3vLbHXMrCS6TKHvyjvmCuE4N1YWoEER6+vptbLsCk5flTKGV2Q==", "d324fd2f-3774-4a0e-99f1-48b6097bf8b9" });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodsLists_MunicipatilyId",
                schema: "mundebt",
                table: "PeriodsLists",
                column: "MunicipatilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodsLists_Municipalities_MunicipatilyId",
                schema: "mundebt",
                table: "PeriodsLists",
                column: "MunicipatilyId",
                principalSchema: "nomenclatures",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
