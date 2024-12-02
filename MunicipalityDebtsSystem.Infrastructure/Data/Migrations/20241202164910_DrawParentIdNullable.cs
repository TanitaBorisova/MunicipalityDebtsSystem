using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class DrawParentIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
