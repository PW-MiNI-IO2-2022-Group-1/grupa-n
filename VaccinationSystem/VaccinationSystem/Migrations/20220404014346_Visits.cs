using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinationSystem.Migrations
{
    public partial class Visits : Migration
    {
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "Vaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SerialNo = table.Column<int>(type: "int", nullable: false),
                    DiseaseId = table.Column<int>(type: "int", nullable: false),
                    RequiredDoses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccines_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VaccineId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visits_Vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "410adff7-f581-4737-b4d6-0dc9a88dec59", "9998bfd3-2f9f-4d4e-8dad-6d53bbc56ddf", "Patient", "PATIENT" },
                    { "53716615-3a3b-4948-9d28-8076bf328b4a", "c03bf9db-52c1-48c2-a2e3-6a260e652e5f", "Doctor", "DOCTOR" },
                    { "c8076fe7-faf6-757b-3452-6aa5f7a33c6c", "e58613c0-8678-4882-8e6a-03deceafc265", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd", 0, "f519299f-f152-4e3e-a90f-dedca73b62e4", "Administrator", "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEJitHv8MGaoALcRcrwWQ2S3rYmAhsa0nZqAwTs6o9wX98Hq5diRoIzMPrHLHGAuhEQ==", null, false, "8544e7ee-5914-462d-99ad-372618aaba1c", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LicenceId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", 0, "6bae9464-5879-44a5-8eaa-983e46e82a25", "Doctor", "doctor@localhost.com", true, "Default", "Doctor", "-1", false, null, "DOCTOR@LOCALHOST.COM", "DOCTOR@LOCALHOST.COM", "AQAAAAEAACcQAAAAECR/ExJxRFZq/ZZBLRildV76GFX7MnJp1CmSZ9igkbX1ZoxUG8YyRl3CWzif1QVOxQ==", null, false, "01248651-b53d-4eac-9da5-a6c3493df6d1", false, "doctor@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Pesel", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 0, "54b6cc8d-be75-42f7-91bf-d505eb10e525", "Patient", "patient@localhost.com", true, "Default", "Patient", false, null, "PATIENT@LOCALHOST.COM", "PATIENT@LOCALHOST.COM", "AQAAAAEAACcQAAAAEOed9q9vkTxFLVopQTdNiLBlysQDfu4D8OEtRSn5Il3Twdmx6xPy59hOCt7u+QFdpA==", "12345678901", null, false, "f4f68034-f39d-4608-9574-1adef98197e2", false, "patient@localhost.com" });

            migrationBuilder.InsertData(
                table: "Diseases",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { -8, "Polio" },
                    { -7, "Mumps" },
                    { -6, "Measles" },
                    { -5, "Smallpox" },
                    { -4, "Chickenpox" },
                    { -3, "Flu" },
                    { -2, "Covid-21" },
                    { -1, "Covid-19" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c8076fe7-faf6-757b-3452-6aa5f7a33c6c", "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd" },
                    { "410adff7-f581-4737-b4d6-0dc9a88dec59", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a" },
                    { "53716615-3a3b-4948-9d28-8076bf328b4a", "f1076fe7-abf6-420d-8810-6cb0f3a92f6a" }
                });

            migrationBuilder.InsertData(
                table: "Vaccines",
                columns: new[] { "Id", "DiseaseId", "Name", "RequiredDoses", "SerialNo" },
                values: new object[,]
                {
                    { -10, -7, "Mumps", 1, 13245125 },
                    { -9, -6, "Measles", 1, 1142565323 },
                    { -8, -4, "Chickenpox", 1, 42565323 },
                    { -7, -3, "Flu-22", 1, 56591234 },
                    { -6, -3, "Flu-21", 1, 12315659 },
                    { -5, -2, "Pfizer-21", 2, 12354659 },
                    { -4, -5, "Smallpox", 1, 223453464 },
                    { -3, -8, "Sabina", 1, 109923 },
                    { -2, -1, "Prizer", 2, 1099231 },
                    { -1, -1, "Moderna", 2, 12345 }
                });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "Status", "VaccineId" },
                values: new object[] { -3, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 1, -7 });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "Status", "VaccineId" },
                values: new object[] { -2, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 2, -3 });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "Status", "VaccineId" },
                values: new object[] { -1, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 0, -1 });

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_DiseaseId",
                table: "Vaccines",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientId",
                table: "Visits",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VaccineId",
                table: "Visits",
                column: "VaccineId");
        }

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
                name: "Visits");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "Diseases");
        }
    }
}
