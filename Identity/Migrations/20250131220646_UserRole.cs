using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class UserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Code", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LastUpdateDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "745cfc52-13b9-4a4c-baad-f4b11536c49e", 0, "1", "41dc376b-4807-4fc9-b33d-21bd64413590", new DateTime(2024, 1, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), "masoudkiannejad@gmail.com", true, "Power", null, "Admin", new DateTime(2024, 1, 31, 13, 1, 1, 0, DateTimeKind.Unspecified), false, null, "MASOUDKIANNEJAD@GMAIL.COM", "POWERADMIN", "AQAAAAIAAYagAAAAEE454kR60B+oyqRnSyKaFxAkq/nxKJp6ZMqG/LrxR7mdmiazJngr2EMHQOGg8Cax8A==", null, false, "f3d5f839-42ca-4f74-b8c2-ee62db3a8ce6", false, "PowerAdmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "745cfc52-13b9-4a4c-baad-f4b11536c49e");
        }
    }
}
