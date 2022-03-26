using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinationSystem.Data.Migrations
{
    public partial class VaccinationYouAreAVisitNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.CreateTable(
                name: "Visit",
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
                    table.PrimaryKey("PK_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visit_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visit_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visit_Vaccines_VaccineId",
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
                value: "58b6c0d3-7157-4f4b-a38f-e51a12aa1269");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53716615-3a3b-4948-9d28-8076bf328b4a",
                column: "ConcurrencyStamp",
                value: "acc03ee5-f30f-42ab-a2fe-5e3da54bdd6a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8076fe7-faf6-757b-3452-6aa5f7a33c6c",
                column: "ConcurrencyStamp",
                value: "3387cb37-0565-4d80-8beb-40100dd73c44");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac5e071c-e392-486b-833d-20dc893b0c32", "AQAAAAEAACcQAAAAENeLiu8F2ekgSkd9rkWRXXpDi8WkaMogqLxeU+wjDSvpQJJAecPk2mjvvz+she2EfA==", "deeeff34-8b61-4fea-94f7-b7ab5a850fa5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a2d66d1-0e64-4fcd-81f6-cf3ce7455edd", "AQAAAAEAACcQAAAAEFL9BqkLTVDpUYRTrXbMFZh/+Lp4WDsbN9fmUaL2VI1g4lzPhjsQUD8n/LhtzvpQ6Q==", "e9e43b4e-75be-4a4a-82c7-200a3752aa54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0d2017c-7920-4288-8e2d-8384361e779f", "AQAAAAEAACcQAAAAEPc2A1Kh9AY7CKZFtZtVkaKS3h9/BB5Xk6RLoEwPaqqIPG3kgCUPhUmZ//TzpqT97w==", "105efc45-6aec-48f6-ada4-b4542272981f" });

            migrationBuilder.InsertData(
                table: "Visit",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "Status", "VaccineId" },
                values: new object[,]
                {
                    { -3, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 1, -7 },
                    { -2, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 2, -3 },
                    { -1, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 0, -1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visit_DoctorId",
                table: "Visit",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_PatientId",
                table: "Visit",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_VaccineId",
                table: "Visit",
                column: "VaccineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VaccineId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                table: "Vaccinations",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "Status", "VaccineId" },
                values: new object[,]
                {
                    { -3, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 1, -7 },
                    { -2, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 2, -3 },
                    { -1, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 0, -1 }
                });

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
        }
    }
}
