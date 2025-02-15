using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class changerole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80b54bba-8dca-476f-a4ee-f6b48681f8d6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "760d11cb-4f2d-47f6-8342-855a0e92d9d9", "AQAAAAIAAYagAAAAEOXOXSHjJHmYsBsYdjuPqGL6420CtfjKuTcZjTPlDnipJes6nHivTsQ+G8I1zvI3jA==", "8dfdfa0e-6237-411a-a3da-8b732786937b" });
        }
    }
}
