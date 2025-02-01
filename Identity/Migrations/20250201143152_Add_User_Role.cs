using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Add_User_Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "4d3dcfaf-9228-41d4-947e-b267194a5356", null, "Just User site ... ", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80b54bba-8dca-476f-a4ee-f6b48681f8d6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c2f17bf-a8f4-4241-90dc-738e43275b62", "AQAAAAIAAYagAAAAEFCPvHBRHTDU7Sk9kifbVcQ+kdRitso2U2emHX686dOMOgh+dGEvsJqX+y+dlN3rbg==", "8d0309ba-2e68-49a3-92fb-f18720f251c0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3dcfaf-9228-41d4-947e-b267194a5356");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80b54bba-8dca-476f-a4ee-f6b48681f8d6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbe18be7-51a1-4711-96d1-3eb9e4b18ec9", "AQAAAAIAAYagAAAAEDn/F5gDRzYTSxij5HYjnxKSLQ4wvmYm7zAwt20nMCIBcov0mciM2ARAEz4xh6tihg==", "98a4c1b3-a190-4d6d-b789-fe338c948ace" });
        }
    }
}
