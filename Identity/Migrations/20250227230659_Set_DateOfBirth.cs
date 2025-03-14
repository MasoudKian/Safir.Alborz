using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Set_DateOfBirth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "696e7da8-12fd-450c-9700-3ec6ff78c2cf", null, "AQAAAAIAAYagAAAAEN5LwnXjQRxuvDze76MzMpEAUuAD0lYSP7hIxS4wObW3aKmwTcrRUHIFd1wtkba44g==", "fd5ba51c-eedc-4085-a9ac-3449d58743f9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d30875f-1ec8-455e-bffa-7c5f958db186",
                columns: new[] { "CreatedDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2025, 2, 16, 12, 45, 20, 661, DateTimeKind.Local).AddTicks(3479), new DateTime(2025, 2, 16, 12, 45, 20, 662, DateTimeKind.Local).AddTicks(1792) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3dcfaf-9228-41d4-947e-b267194a5356",
                columns: new[] { "CreatedDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2025, 2, 16, 12, 45, 20, 663, DateTimeKind.Local).AddTicks(2689), new DateTime(2025, 2, 16, 12, 45, 20, 663, DateTimeKind.Local).AddTicks(2695) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80b54bba-8dca-476f-a4ee-f6b48681f8d6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8da46158-1374-48ec-93c7-66ac43ffa3f3", "AQAAAAIAAYagAAAAEEJj7psgUrBokgaT/AKihrfVz2J4i4hn9B3uYCCKncCvVYQsPfbAJ58inmbUovmIlQ==", "ac347226-4c58-48cd-bc16-d033c62341b6" });
        }
    }
}
