using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PeriodListCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1628c160-f17f-4ba2-aa59-67d2825faf77", "AQAAAAIAAYagAAAAEMsaEQdisZIexda1iZqBEnw8/z9ihZpD2O8cPFcQH5bkaLK6rbQTI9wBdxFlgoQj5A==", "d11f5913-39a3-4ff0-a031-e54dbbe8d887" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c8a9057-8c21-4cfa-8941-d310a8848a18", "AQAAAAIAAYagAAAAELV5dtZgZhlZUJggmhT5OoaW6NpI5FNZR/lBmXKEDw85/+dj/QdQv0HaoNpu1JFJdg==", "608d8907-bd39-4f99-9423-aba05bf9c4eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "242ad719-6a3b-44fd-a704-01ca71f8b9da", "AQAAAAIAAYagAAAAEB25+ydR9eQDHzfqMn3Gg09UPqD5FQxUbvhESKZgzDcA6X2EDG1lDpmgV02SvSlYow==", "971964bc-eb08-443d-8f38-dc1bf81477cd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0381343f-fbad-4eb9-9285-58c595d71a9d", "AQAAAAIAAYagAAAAEBsGvcd9GP39KENFml8O8t7TeGPh8Vlp6Vb/4zEtZ5zd1oA3p3sVxVp76FmKSu5oRA==", "a2e5e722-73e6-428e-89a2-7b4de3d6f945" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "298aad41-7402-4afc-b9d1-cb68b84e1672", "AQAAAAIAAYagAAAAELx78/hB/cZUKSPkCpx138bzv4HXCZfnfDEe2WS4BSK6AH5EewmGVtYUc+0o2+0Adg==", "884afb47-eb05-4c0e-8a45-6a820dc85910" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e69b97f-2c08-4392-b738-2678fb92391d", "AQAAAAIAAYagAAAAENeDjm3ITKkMeMwinJXQW5EPtA5kU+tZLBHXwV9oBuR9n4+IRSs21N4+2Ud57A4/cg==", "43e43330-2ee3-4c65-b129-b9e8288050a3" });
        }
    }
}
