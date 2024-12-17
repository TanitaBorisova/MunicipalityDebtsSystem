using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ab22363-bc7b-4ba8-9f32-a55a4ec2a226", "AQAAAAIAAYagAAAAEIIxbivkStls8jzTQPTjPgWpFtq+97jWHdtcZ8EcwNdFljkZXhQxCccWvqbdTLEkvA==", "5c3fdf1a-c4ea-4e2b-9bf8-c1740a6b5734" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edbb648f-1f0e-49d5-9e51-8433484c712f", "AQAAAAIAAYagAAAAEMcFx9F4sNFLoMnM5XL7XkRNkWNZTRKSSQBrUR83Vi5wlt9RLW/5nZ3UQbxeqXRusQ==", "0c552b5e-3c89-45ac-b012-265eec16e62a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71a5a11f-fc4e-4528-9349-d8f92d2a05c9", "AQAAAAIAAYagAAAAEIRJhC+BOjH9t7ehEvHZxgsaM37vE/zbQXOEi6pZG9WtYQQt/4jaLeFB457WWSKcYQ==", "7a303be7-cb06-4890-b499-6877b0e82401" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
