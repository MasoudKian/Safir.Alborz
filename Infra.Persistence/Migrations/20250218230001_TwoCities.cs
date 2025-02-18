using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TwoCities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "مرند", 1 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "ارومیه", 2 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "خوی", 2 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "اردبیل", 3 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "مشگین‌شهر", 3 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "اصفهان", 4 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "نجف‌آباد", 4 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "کرج", 5 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "نظرآباد", 5 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "ایلام", 6 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "دهلران", 6 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "بوشهر", 7 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "دشتی", 7 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "تهران", 8 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "ری", 8 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "شهرکرد", 9 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "بروجن", 9 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "بیرجند", 10 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "قائن", 10 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "مشهد", 11 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "تربت حیدریه", 11 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "بجنورد", 12 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "آشخانه", 12 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "اهواز", 13 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "دزفول", 13 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "زنجان", 14 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "خرمدره", 14 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "سمنان", 15 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "شاهرود", 15 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "زاهدان", 16 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IsDelete", "LastModifiedBy", "Name", "ProvinceId", "RegisteredBy", "RegisteredDate", "UpdateDate" },
                values: new object[,]
                {
                    { 32, false, null, "خاش", 16, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, false, null, "شیراز", 17, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, false, null, "مرودشت", 17, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, false, null, "قزوین", 18, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, false, null, "آبیک", 18, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, false, null, "قم", 19, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, false, null, "کاشان", 19, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, false, null, "سنندج", 20, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, false, null, "کامیاران", 20, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, false, null, "کرمان", 21, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, false, null, "راور", 21, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, false, null, "کرمانشاه", 22, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, false, null, "پاوه", 22, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, false, null, "یاسوج", 23, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, false, null, "دنا", 23, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, false, null, "گرگان", 24, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, false, null, "آق‌قلا", 24, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, false, null, "رشت", 25, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, false, null, "آستارا", 25, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, false, null, "خرم‌آباد", 26, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, false, null, "الیگودرز", 26, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, false, null, "ساری", 27, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, false, null, "آمل", 27, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, false, null, "اراک", 28, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, false, null, "خمین", 28, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, false, null, "بندرعباس", 29, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, false, null, "قشم", 29, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, false, null, "همدان", 30, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, false, null, "ملایر", 30, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, false, null, "یزد", 31, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, false, null, "اردکان", 31, "Masou With Seed Data", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "ارومیه", 2 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "اردبیل", 3 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "اصفهان", 4 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "کرج", 5 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "ایلام", 6 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "بوشهر", 7 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "تهران", 8 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "شهرکرد", 9 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "بیرجند", 10 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "مشهد", 11 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "بجنورد", 12 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "اهواز", 13 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "زنجان", 14 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "سمنان", 15 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "زاهدان", 16 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "شیراز", 17 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "قزوین", 18 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "قم", 19 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "سنندج", 20 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "کرمان", 21 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "کرمانشاه", 22 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "یاسوج", 23 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "گرگان", 24 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "رشت", 25 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "خرم‌آباد", 26 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "ساری", 27 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "اراک", 28 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "بندرعباس", 29 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "همدان", 30 });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Name", "ProvinceId" },
                values: new object[] { "یزد", 31 });
        }
    }
}
