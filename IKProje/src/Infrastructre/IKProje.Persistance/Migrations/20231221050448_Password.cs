using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IKProje.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Password : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meslekler",
                keyColumn: "Id",
                keyValue: "70e7bf23-f75c-4f4a-a04e-97dbbe6d022c");

            migrationBuilder.DeleteData(
                table: "Meslekler",
                keyColumn: "Id",
                keyValue: "85795b06-efef-436c-9cf4-ad47f64b01f2");

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: "Ik",
                column: "CreatedTime",
                value: new DateTime(2023, 12, 21, 8, 4, 47, 84, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: "Yazılım",
                column: "CreatedTime",
                value: new DateTime(2023, 12, 21, 8, 4, 47, 978, DateTimeKind.Local).AddTicks(7909));

            migrationBuilder.InsertData(
                table: "Meslekler",
                columns: new[] { "Id", "CreatedTime", "IsActive", "LastUpdatedTime", "Name" },
                values: new object[,]
                {
                    { "8691ef83-fc9d-4c4e-8dd4-3476ac7cc976", new DateTime(2023, 12, 21, 8, 4, 47, 981, DateTimeKind.Local).AddTicks(1066), true, null, "Satiş Müdürü" },
                    { "e9c46894-3c29-4a04-b0c9-b31e9ac9742c", new DateTime(2023, 12, 21, 8, 4, 47, 93, DateTimeKind.Local).AddTicks(6998), true, null, "Developer" }
                });

            migrationBuilder.UpdateData(
                table: "Sirketler",
                keyColumn: "Id",
                keyValue: "Ulker",
                column: "CreatedTime",
                value: new DateTime(2023, 12, 21, 8, 4, 47, 74, DateTimeKind.Local).AddTicks(6470));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meslekler",
                keyColumn: "Id",
                keyValue: "8691ef83-fc9d-4c4e-8dd4-3476ac7cc976");

            migrationBuilder.DeleteData(
                table: "Meslekler",
                keyColumn: "Id",
                keyValue: "e9c46894-3c29-4a04-b0c9-b31e9ac9742c");

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: "Ik",
                column: "CreatedTime",
                value: new DateTime(2023, 12, 20, 14, 59, 53, 304, DateTimeKind.Local).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: "Yazılım",
                column: "CreatedTime",
                value: new DateTime(2023, 12, 20, 14, 59, 56, 546, DateTimeKind.Local).AddTicks(9624));

            migrationBuilder.InsertData(
                table: "Meslekler",
                columns: new[] { "Id", "CreatedTime", "IsActive", "LastUpdatedTime", "Name" },
                values: new object[,]
                {
                    { "70e7bf23-f75c-4f4a-a04e-97dbbe6d022c", new DateTime(2023, 12, 20, 14, 59, 56, 552, DateTimeKind.Local).AddTicks(1410), true, null, "Satiş Müdürü" },
                    { "85795b06-efef-436c-9cf4-ad47f64b01f2", new DateTime(2023, 12, 20, 14, 59, 53, 329, DateTimeKind.Local).AddTicks(4705), true, null, "Developer" }
                });

            migrationBuilder.UpdateData(
                table: "Sirketler",
                keyColumn: "Id",
                keyValue: "Ulker",
                column: "CreatedTime",
                value: new DateTime(2023, 12, 20, 14, 59, 53, 290, DateTimeKind.Local).AddTicks(2878));
        }
    }
}
