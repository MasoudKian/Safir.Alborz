using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class SetUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3dcfaf-9228-41d4-947e-b267194a5356");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "717f2382-d718-455d-a238-47df91977d71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb275765-1cac-4652-a03f-f8871dd575d1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "745cfc52-13b9-4a4c-baad-f4b11536c49e");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cb275765-1cac-4652-a03f-f8871dd575d1", "745cfc52-13b9-4a4c-baad-f4b11536c49e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cb275765-1cac-4652-a03f-f8871dd575d1", "745cfc52-13b9-4a4c-baad-f4b11536c49e" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d3dcfaf-9228-41d4-947e-b267194a5356", null, "User site ... ", "User", "USER" },
                    { "717f2382-d718-455d-a238-47df91977d71", null, "Just admin ... ", "Admin", "ADMIN" },
                    { "cb275765-1cac-4652-a03f-f8871dd575d1", null, "Responsible for the entire site", "PowerAdmin", "POWERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Code", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LastUpdateDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "745cfc52-13b9-4a4c-baad-f4b11536c49e", 0, "1", "41dc376b-4807-4fc9-b33d-21bd64413590", new DateTime(2024, 1, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), "masoudkiannejad@gmail.com", true, "Power", null, "Admin", new DateTime(2024, 1, 31, 13, 1, 1, 0, DateTimeKind.Unspecified), false, null, "MASOUDKIANNEJAD@GMAIL.COM", "POWERADMIN", "AQAAAAIAAYagAAAAEE454kR60B+oyqRnSyKaFxAkq/nxKJp6ZMqG/LrxR7mdmiazJngr2EMHQOGg8Cax8A==", null, false, "f3d5f839-42ca-4f74-b8c2-ee62db3a8ce6", false, "PowerAdmin" });
        }
    }
}
