using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class set_AdminPanel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d30875f-1ec8-455e-bffa-7c5f958db186",
                columns: new[] { "CreatedDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2025, 4, 4, 22, 11, 59, 830, DateTimeKind.Local).AddTicks(1561), new DateTime(2025, 4, 4, 22, 11, 59, 836, DateTimeKind.Local).AddTicks(1677) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3dcfaf-9228-41d4-947e-b267194a5356",
                columns: new[] { "CreatedDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2025, 4, 4, 22, 11, 59, 839, DateTimeKind.Local).AddTicks(5662), new DateTime(2025, 4, 4, 22, 11, 59, 839, DateTimeKind.Local).AddTicks(5679) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "IsDelete", "LastUpdateDate", "Name", "NormalizedName" },
                values: new object[] { "4d3dcfaf-9228-41d4-947e-b267194a5355", null, new DateTime(2025, 4, 4, 22, 11, 59, 839, DateTimeKind.Local).AddTicks(5940), "With For Accepted Admin Panel", false, new DateTime(2025, 4, 4, 22, 11, 59, 839, DateTimeKind.Local).AddTicks(5941), "AdminPanel", "ADMINPANEL" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80b54bba-8dca-476f-a4ee-f6b48681f8d6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46262bd2-005e-4cf0-938e-9b35dc586f2f", "AQAAAAIAAYagAAAAEMkYT2HDzUEKzaB4dfGVSbx8Ic3Bhrj5quSufKBajXeENy3W1x5ZiuW86fsdMuFdaQ==", "84f51c34-5bc8-4a6e-af3c-c36c8322c0a1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4d3dcfaf-9228-41d4-947e-b267194a5355", "80b54bba-8dca-476f-a4ee-f6b48681f8d6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4d3dcfaf-9228-41d4-947e-b267194a5355", "80b54bba-8dca-476f-a4ee-f6b48681f8d6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3dcfaf-9228-41d4-947e-b267194a5355");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d30875f-1ec8-455e-bffa-7c5f958db186",
                columns: new[] { "CreatedDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2025, 2, 28, 2, 36, 55, 238, DateTimeKind.Local).AddTicks(4328), new DateTime(2025, 2, 28, 2, 36, 55, 240, DateTimeKind.Local).AddTicks(461) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3dcfaf-9228-41d4-947e-b267194a5356",
                columns: new[] { "CreatedDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2025, 2, 28, 2, 36, 55, 241, DateTimeKind.Local).AddTicks(9303), new DateTime(2025, 2, 28, 2, 36, 55, 241, DateTimeKind.Local).AddTicks(9307) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80b54bba-8dca-476f-a4ee-f6b48681f8d6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "696e7da8-12fd-450c-9700-3ec6ff78c2cf", "AQAAAAIAAYagAAAAEN5LwnXjQRxuvDze76MzMpEAUuAD0lYSP7hIxS4wObW3aKmwTcrRUHIFd1wtkba44g==", "fd5ba51c-eedc-4085-a9ac-3449d58743f9" });
        }
    }
}
