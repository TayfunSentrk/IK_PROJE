using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IKProje.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departmanlar",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmanlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IzınTurleri",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Duration = table.Column<byte>(type: "tinyint", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzınTurleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meslekler",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meslekler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sirketler",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MersisNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VergiNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VergiDairesi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalisanSayisi = table.Column<int>(type: "int", nullable: false),
                    KurulusTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SozlesmeBaslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SozlesmeBitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sirketler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TCIdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDateOfWork = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDateOfWork = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsedAdvance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NumberofAdvance = table.Column<int>(type: "int", nullable: true),
                    AdvanceRenewalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departmanlar_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Meslekler_VocationId",
                        column: x => x.VocationId,
                        principalTable: "Meslekler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Sirketler_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Sirketler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmanŞirketler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmanŞirketler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmanŞirketler_Departmanlar_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmanŞirketler_Sirketler_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Sirketler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avanslar",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    TypeofAdvance = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateofReply = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusofApproval = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avanslar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avanslar_AspNetUsers_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avanslar_Sirketler_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Sirketler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Harcamalar",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    TypeofExpenses = table.Column<int>(type: "int", nullable: false),
                    Documantation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateofReply = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusofApproval = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harcamalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harcamalar_AspNetUsers_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Harcamalar_Sirketler_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Sirketler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Izinler",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DayCount = table.Column<byte>(type: "tinyint", nullable: false),
                    TypeofPermissionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateofReply = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusofApproval = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izinler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Izinler_AspNetUsers_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Izinler_IzınTurleri_TypeofPermissionId",
                        column: x => x.TypeofPermissionId,
                        principalTable: "IzınTurleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Izinler_Sirketler_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Sirketler",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmanId",
                table: "AspNetUsers",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VocationId",
                table: "AspNetUsers",
                column: "VocationId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Avanslar_CompanyId",
                table: "Avanslar",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Avanslar_PersonelId",
                table: "Avanslar",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmanŞirketler_CompanyId",
                table: "DepartmanŞirketler",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmanŞirketler_DepartmanId",
                table: "DepartmanŞirketler",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Harcamalar_CompanyId",
                table: "Harcamalar",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Harcamalar_PersonelId",
                table: "Harcamalar",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_CompanyId",
                table: "Izinler",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_PersonelId",
                table: "Izinler",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_TypeofPermissionId",
                table: "Izinler",
                column: "TypeofPermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Avanslar");

            migrationBuilder.DropTable(
                name: "DepartmanŞirketler");

            migrationBuilder.DropTable(
                name: "Harcamalar");

            migrationBuilder.DropTable(
                name: "Izinler");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "IzınTurleri");

            migrationBuilder.DropTable(
                name: "Departmanlar");

            migrationBuilder.DropTable(
                name: "Meslekler");

            migrationBuilder.DropTable(
                name: "Sirketler");
        }
    }
}
