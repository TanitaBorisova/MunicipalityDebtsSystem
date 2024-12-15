using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsFinishAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                schema: "mundebt",
                table: "Debts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Shows if the debt is finished");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "840ddc00-ffd3-4338-b1bb-6d44f8adb7d9", "AQAAAAIAAYagAAAAEBD6GdPNRDt5Po9M3K1I8uujBLfzWQyvITRrHoKRoIelje1CdU2Lgf/tpfVxOMg2pg==", "cba33c5f-aa3a-4e0c-83a1-1a26eeb6f78d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c229126-1a28-494d-bf87-f1a90df84c1c", "AQAAAAIAAYagAAAAEKNHycbKilwKkHBaKKQY34E2c4Lq3eEYa4AhpB+sKzg8hanbuKApUpdqpBoYq1Xbzg==", "69c38437-27cf-4225-b784-b16ebedebeb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8f527e8-7303-41bd-9052-8738bf75c690", "AQAAAAIAAYagAAAAEOIbhN6G+CSFH5rYYOpmQqUlh6tqxIGM+f2snnwZeIRD52CVHnlpmf/g86b8RIvHBw==", "5ed1f3e9-9442-4eaa-b2c5-05b4cdc73910" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                schema: "mundebt",
                table: "Debts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67736c7e-4885-4c1a-800d-96d10a587d9b", "AQAAAAIAAYagAAAAELtjdBqZ8nUJjvKo+yfC6szsLOZO2rVw3Eddz5yJ1eZoi8ZV0kfPIdh0/dABswN5ZQ==", "0470e52e-9901-41fe-ba4a-304462a22130" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c327dd1d-482e-4d5e-b554-bdb29555d56d", "AQAAAAIAAYagAAAAEPpsXAt/+s7jfI0jR7N86GeCRWPT9vUEioIyDf+SINLG/jMpNGQ+lvmFYg3IyCI9kg==", "4bc5c540-3f51-456d-abdf-fde8973e5957" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7adb7e4b-7f1c-49ee-ac70-9b6728d31695", "AQAAAAIAAYagAAAAENwUFsMMDDiOJIMFWnRGmF6ugPoW92uy3z14Ww1U5Uj+BTAoClsAzw7FNLTeb5ndAQ==", "820ba0d8-7c4e-4160-8783-521a57468f7c" });
        }
    }
}
