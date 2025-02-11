using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class deleteImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80b54bba-8dca-476f-a4ee-f6b48681f8d6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "760d11cb-4f2d-47f6-8342-855a0e92d9d9", "AQAAAAIAAYagAAAAEOXOXSHjJHmYsBsYdjuPqGL6420CtfjKuTcZjTPlDnipJes6nHivTsQ+G8I1zvI3jA==", "8dfdfa0e-6237-411a-a3da-8b732786937b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80b54bba-8dca-476f-a4ee-f6b48681f8d6",
                columns: new[] { "ConcurrencyStamp", "Image", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11e88ed3-6b19-44ab-a372-64ff74e01d46", null, "AQAAAAIAAYagAAAAEBPJxaSjW+MH7nzCtdARBrR3klQsw8uGt9VKFwVNHc6qn9/cf+2PmU3QaOzFnArYqA==", "f39171ca-3c01-48f5-94ff-cb2fb77c863e" });
        }
    }
}
