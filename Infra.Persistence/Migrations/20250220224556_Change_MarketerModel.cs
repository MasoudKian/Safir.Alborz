using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Change_MarketerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Marketers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MarketerCode",
                table: "Marketers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Marketers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Marketers_CityId",
                table: "Marketers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Marketers_ProvinceId",
                table: "Marketers",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marketers_Cities_CityId",
                table: "Marketers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marketers_Provinces_ProvinceId",
                table: "Marketers",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marketers_Cities_CityId",
                table: "Marketers");

            migrationBuilder.DropForeignKey(
                name: "FK_Marketers_Provinces_ProvinceId",
                table: "Marketers");

            migrationBuilder.DropIndex(
                name: "IX_Marketers_CityId",
                table: "Marketers");

            migrationBuilder.DropIndex(
                name: "IX_Marketers_ProvinceId",
                table: "Marketers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Marketers");

            migrationBuilder.DropColumn(
                name: "MarketerCode",
                table: "Marketers");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Marketers");
        }
    }
}
