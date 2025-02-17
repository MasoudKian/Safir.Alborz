using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class setIndexForCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Regions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_Code",
                table: "Regions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ProvinceId",
                table: "Regions",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeID",
                table: "Employees",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Provinces_ProvinceId",
                table: "Regions",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Provinces_ProvinceId",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Regions_Code",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Regions_ProvinceId",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Regions");
        }
    }
}
