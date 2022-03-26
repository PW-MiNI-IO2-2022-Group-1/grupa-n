using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinationSystem.Data.Migrations
{
    public partial class AddAndSeedVaccinesAndVaccinations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VaccineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccinations_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaccinations_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vaccinations_Vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "410adff7-f581-4737-b4d6-0dc9a88dec59",
                column: "ConcurrencyStamp",
                value: "fdb1c17b-43f3-4e9f-be78-a9d2a33684ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53716615-3a3b-4948-9d28-8076bf328b4a",
                column: "ConcurrencyStamp",
                value: "c4bc4328-c81a-45ae-a79a-39bee1727a6c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8076fe7-faf6-757b-3452-6aa5f7a33c6c",
                column: "ConcurrencyStamp",
                value: "355f5f16-f026-4d2d-b3bc-419cc909a59d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e0f2a4b-b618-4fac-a4c7-5d7ced330aae", "AQAAAAEAACcQAAAAELKyG0+3/5m+7FzSTRGgfIzBK5kb9aroaZersKg/GvSf2oIUfOd1n5f7xYmO5bXPPQ==", "196330bb-5f4e-4fa7-87a9-57f3fa7bcb4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "722c77d3-6b4d-4725-b0bf-f98d1b1ecd10", "AQAAAAEAACcQAAAAEJvESQsc8/RNmrINmTu8YpXcukeBv6eGKsUJDhJ84eK3BHHo4XxlCtboTtlCIktWgw==", "0001269b-48fc-4f07-8d45-67b59e3ce8e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45741f5b-883f-47b9-b9bf-513b4a77b7e7", "AQAAAAEAACcQAAAAEAPSUDv1u32767MAhRvRJGFiS/JNgwhD10XvqcLpNjtUFX6L1AreePuxbL09nUXO0w==", "04f0d32f-76e2-45e8-928d-77ba2a5488d7" });

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
                table: "Vaccinations",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "Status", "VaccineId" },
                values: new object[] { -3, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 1, -7 });

            migrationBuilder.InsertData(
                table: "Vaccinations",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "Status", "VaccineId" },
                values: new object[] { -2, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 2, -3 });

            migrationBuilder.InsertData(
                table: "Vaccinations",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "Status", "VaccineId" },
                values: new object[] { -1, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 0, -1 });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_DoctorId",
                table: "Vaccinations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_PatientId",
                table: "Vaccinations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_VaccineId",
                table: "Vaccinations",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_DiseaseId",
                table: "Vaccines",
                column: "DiseaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "410adff7-f581-4737-b4d6-0dc9a88dec59",
                column: "ConcurrencyStamp",
                value: "e6ef3c99-c714-460a-8a30-2afe67ca8a3b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53716615-3a3b-4948-9d28-8076bf328b4a",
                column: "ConcurrencyStamp",
                value: "eefd876d-3274-4d36-9ff1-1af2d66aec32");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8076fe7-faf6-757b-3452-6aa5f7a33c6c",
                column: "ConcurrencyStamp",
                value: "9af34cf0-d516-40ee-a5e1-7a7106362c9d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e973c68-c2f9-4000-b586-e0743dbd13c5", "AQAAAAEAACcQAAAAEPBGW/Zz6oqHBY4a28iHrxSrxFUH/4+iHlhSmTAmrE6oEFjpyDD6EWty/pFoIK/MMg==", "7eba0b8e-69f0-424a-b309-73ce758f3205" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e71819a-e7f6-4d53-a11e-b50574af7ebe", "AQAAAAEAACcQAAAAELAkVDzvBljvSYcbrJ0b+gssUBWL8m38W434YrHlQrhTQDvjlLhqi2Y3gPFD+i+a/A==", "3f88f172-8ed2-4552-895f-fcdf6e13f4d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ba179de-fa7b-405a-8179-680bc755f1e3", "AQAAAAEAACcQAAAAEK637eNajfOajPTHXrNCt7c6QnifwUZWm/LECP0/pESRSZzdoFNDd52gWPh5U8LwcQ==", "c427f190-f1d1-4b64-938e-7679bd084ee4" });
        }
    }
}
