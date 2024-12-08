using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityDebtsSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class correctAdminEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f890d53c-9541-4dfa-a27e-438664986fb1", "ADMINDEBT@MAIL.BG", "ADMINDEBT@MAIL.BG", "AQAAAAIAAYagAAAAEPoMEkwlFeP64WewjwPp3SOlCPzIUGEiwmzHRCnOSnqvHvpsLMMY0uquKoONHwACQw==", "57bd9e73-943d-4482-a600-635a79872a4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "345501da-44a0-4f9d-a8be-b99b75ab8c27", "AQAAAAIAAYagAAAAEEgbe4WEjcPV3Ti/3vLbHXMrCS6TKHvyjvmCuE4N1YWoEER6+vptbLsCk5flTKGV2Q==", "d324fd2f-3774-4a0e-99f1-48b6097bf8b9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ad10a0-2f69-4735-bd2c-9e944cd80baf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92fb716f-b49d-4292-8633-27b39f514ba2", "AQAAAAIAAYagAAAAEMYoy+ViY55B5Ta8VwdEVo2YwcJY2YzgifmRU6LnbzKBxLtUp69sn8PMTcedDE73Og==", "46174673-e02a-4438-ae82-9ecbb38067ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "021acb66-2ef9-45a6-b508-2b913a8ee82c", "ADMINDEBT@MAIL.COM", "ADMINDEBT@MAIL.COM", "AQAAAAIAAYagAAAAEFqk9yEZJHIDxMWdMVWWvO8aaArQDIptgHL0DJb/HLZkEL1igA6saAbgZBCHT96yuA==", "3b8e552f-87fe-4d96-93cc-22fc2a492788" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf648ad-8f38-459d-909f-256f9a167a44",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6edfab1a-4f24-405a-80a6-e9bf5eb89f85", "AQAAAAIAAYagAAAAEPWlUADeeLrMKB+r/6wNFm5kWnrcJkC0oQex35fJ1Rp5vbu+lBorquhzX1VCzGohBA==", "c39e465a-a0af-4679-9364-50e97e6ee572" });
        }
    }
}
