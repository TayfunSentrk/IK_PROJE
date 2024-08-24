using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IKProje.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Inital9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: "69173156-a937-4224-b9d0-d8e89a1b9f2f");

            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: "af750a1f-fba7-4db8-b503-cabc67df257c");

            migrationBuilder.DeleteData(
                table: "Meslekler",
                keyColumn: "Id",
                keyValue: "80ae71ee-bc4f-430c-ac7d-44b089c59c72");

            migrationBuilder.DeleteData(
                table: "Meslekler",
                keyColumn: "Id",
                keyValue: "b22f7186-53b9-4616-a628-f0e9376490c9");

            migrationBuilder.DeleteData(
                table: "Sirketler",
                keyColumn: "Id",
                keyValue: "7bccb460-a7da-4770-9744-c96d67977bd5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Admin", null, "Admin", null },
                    { "Yönetici", null, "Yönetici", null }
                });

            migrationBuilder.InsertData(
                table: "Departmanlar",
                columns: new[] { "Id", "CreatedTime", "IsActive", "LastUpdatedTime", "Name" },
                values: new object[,]
                {
                    { "Ik", new DateTime(2023, 12, 20, 14, 59, 53, 304, DateTimeKind.Local).AddTicks(6602), true, null, "Ik" },
                    { "Yazılım", new DateTime(2023, 12, 20, 14, 59, 56, 546, DateTimeKind.Local).AddTicks(9624), true, null, "Yazılım" }
                });

            migrationBuilder.InsertData(
                table: "Meslekler",
                columns: new[] { "Id", "CreatedTime", "IsActive", "LastUpdatedTime", "Name" },
                values: new object[,]
                {
                    { "70e7bf23-f75c-4f4a-a04e-97dbbe6d022c", new DateTime(2023, 12, 20, 14, 59, 56, 552, DateTimeKind.Local).AddTicks(1410), true, null, "Satiş Müdürü" },
                    { "85795b06-efef-436c-9cf4-ad47f64b01f2", new DateTime(2023, 12, 20, 14, 59, 53, 329, DateTimeKind.Local).AddTicks(4705), true, null, "Developer" }
                });

            migrationBuilder.InsertData(
                table: "Sirketler",
                columns: new[] { "Id", "Adres", "CalisanSayisi", "CreatedTime", "IsActive", "KurulusTarihi", "LastUpdatedTime", "LogoPath", "Mail", "MersisNo", "Name", "Phone", "SozlesmeBaslangic", "SozlesmeBitis", "Unvan", "VergiDairesi", "VergiNo" },
                values: new object[] { "Ulker", "Kısıklı Mahallesi, Ferah Caddesi No: 1, 34692 Büyükçamlıca-Üsküdar, İstanbul, Türkiye", 51000, new DateTime(2023, 12, 20, 14, 59, 53, 290, DateTimeKind.Local).AddTicks(2878), true, new DateTime(1944, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "ir@ulker.com.tr", "0920-0034-0390-0011", "Ulker", "02165242500", new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Ş", "Büyük Mükellefler", "906 002 2039" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Yönetici");

            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: "Ik");

            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: "Yazılım");

            migrationBuilder.DeleteData(
                table: "Meslekler",
                keyColumn: "Id",
                keyValue: "70e7bf23-f75c-4f4a-a04e-97dbbe6d022c");

            migrationBuilder.DeleteData(
                table: "Meslekler",
                keyColumn: "Id",
                keyValue: "85795b06-efef-436c-9cf4-ad47f64b01f2");

            migrationBuilder.DeleteData(
                table: "Sirketler",
                keyColumn: "Id",
                keyValue: "Ulker");

            migrationBuilder.InsertData(
                table: "Departmanlar",
                columns: new[] { "Id", "CreatedTime", "IsActive", "LastUpdatedTime", "Name" },
                values: new object[,]
                {
                    { "69173156-a937-4224-b9d0-d8e89a1b9f2f", new DateTime(2023, 12, 17, 22, 25, 45, 882, DateTimeKind.Local).AddTicks(7845), true, null, "Ik" },
                    { "af750a1f-fba7-4db8-b503-cabc67df257c", new DateTime(2023, 12, 17, 22, 25, 46, 948, DateTimeKind.Local).AddTicks(5714), true, null, "Yazılım" }
                });

            migrationBuilder.InsertData(
                table: "Meslekler",
                columns: new[] { "Id", "CreatedTime", "IsActive", "LastUpdatedTime", "Name" },
                values: new object[,]
                {
                    { "80ae71ee-bc4f-430c-ac7d-44b089c59c72", new DateTime(2023, 12, 17, 22, 25, 45, 894, DateTimeKind.Local).AddTicks(915), true, null, "Developer" },
                    { "b22f7186-53b9-4616-a628-f0e9376490c9", new DateTime(2023, 12, 17, 22, 25, 46, 952, DateTimeKind.Local).AddTicks(536), true, null, "Satiş Müdürü" }
                });

            migrationBuilder.InsertData(
                table: "Sirketler",
                columns: new[] { "Id", "Adres", "CalisanSayisi", "CreatedTime", "IsActive", "KurulusTarihi", "LastUpdatedTime", "LogoPath", "Mail", "MersisNo", "Name", "Phone", "SozlesmeBaslangic", "SozlesmeBitis", "Unvan", "VergiDairesi", "VergiNo" },
                values: new object[] { "7bccb460-a7da-4770-9744-c96d67977bd5", "Kısıklı Mahallesi, Ferah Caddesi No: 1, 34692 Büyükçamlıca-Üsküdar, İstanbul, Türkiye", 51000, new DateTime(2023, 12, 17, 22, 25, 45, 855, DateTimeKind.Local).AddTicks(9901), true, new DateTime(1944, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "ir@ulker.com.tr", "0920-0034-0390-0011", "Ulker", "02165242500", new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.Ş", "Büyük Mükellefler", "906 002 2039" });
        }
    }
}
