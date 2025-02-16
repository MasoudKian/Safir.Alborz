using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Set_IsDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d30875f-1ec8-455e-bffa-7c5f958db186",
                columns: new[] { "CreatedDate", "IsDelete", "LastUpdateDate" },
                values: new object[] { new DateTime(2025, 2, 16, 12, 45, 20, 661, DateTimeKind.Local).AddTicks(3479), false, new DateTime(2025, 2, 16, 12, 45, 20, 662, DateTimeKind.Local).AddTicks(1792) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3dcfaf-9228-41d4-947e-b267194a5356",
                columns: new[] { "CreatedDate", "IsDelete", "LastUpdateDate" },
                values: new object[] { new DateTime(2025, 2, 16, 12, 45, 20, 663, DateTimeKind.Local).AddTicks(2689), false, new DateTime(2025, 2, 16, 12, 45, 20, 663, DateTimeKind.Local).AddTicks(2695) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80b54bba-8dca-476f-a4ee-f6b48681f8d6",
                columns: new[] { "ConcurrencyStamp", "IsDelete", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8da46158-1374-48ec-93c7-66ac43ffa3f3", false, "AQAAAAIAAYagAAAAEEJj7psgUrBokgaT/AKihrfVz2J4i4hn9B3uYCCKncCvVYQsPfbAJ58inmbUovmIlQ==", "ac347226-4c58-48cd-bc16-d033c62341b6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d30875f-1ec8-455e-bffa-7c5f958db186",
                columns: new[] { "CreatedDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2025, 2, 15, 13, 2, 34, 614, DateTimeKind.Local).AddTicks(4785), new DateTime(2025, 2, 15, 13, 2, 34, 615, DateTimeKind.Local).AddTicks(2025) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3dcfaf-9228-41d4-947e-b267194a5356",
                columns: new[] { "CreatedDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2025, 2, 15, 13, 2, 34, 616, DateTimeKind.Local).AddTicks(2395), new DateTime(2025, 2, 15, 13, 2, 34, 616, DateTimeKind.Local).AddTicks(2397) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80b54bba-8dca-476f-a4ee-f6b48681f8d6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f425b9d-0936-4bb4-8b30-86f4d50e6659", "AQAAAAIAAYagAAAAEEVWyLCyHi+n2lGwExCOZA3MY2xsdNRP16X5IhrdTn5lnPEgcVqzxMvJW51Hu7FF7g==", "f5103983-cd05-44f4-bc20-8beef6f267a4" });
        }
    }
}
