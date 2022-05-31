using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinationSystem.Migrations
{
    public partial class nw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BugReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BugReports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "c47f1d7f-eb38-4421-a5f9-1b78b255b5d9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "46172b24-8cba-41e8-a080-d6a3ab0d33f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "fb353d99-8c4f-45f3-aa38-b99e5f2825c4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "79bd0449-c9c8-4063-907f-eabb8d473884", "AQAAAAEAACcQAAAAEDXgEs0kXU91biF9qfssZbtKi7rWecP+GUFs7c3xlUFVYilhyhj3HpMWB3bC7PrhAw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a927042a-f7a8-47bf-b4cd-ac78a23051b3", "AQAAAAEAACcQAAAAEK0908/GFIqJSN4nNP5aKlmiKFOtSl2mj6Wa6j3WF63yxjmiQMpqCVM/tkI0NaBLsQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe4d0e20-3a7a-4c05-85cb-34fed040b90e", "AQAAAAEAACcQAAAAEF+9fpomZI4oFqd6Ty/my34t0UERFxO1S1IOqE3z5PY8tEYz+61itorOrm5VU5UavA==" });

            migrationBuilder.InsertData(
                table: "BugReports",
                columns: new[] { "Id", "Date", "Description", "Origin", "UserId" },
                values: new object[] { -1, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stuck on loading", 0, -3 });

            migrationBuilder.CreateIndex(
                name: "IX_BugReports_UserId",
                table: "BugReports",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BugReports");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "7e75f4fe-b309-4c26-8098-93d50d6d6cec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "3541c308-59c4-41fc-b701-3386197f0307");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "e5cbe87c-31cd-469a-aa95-2f2ac995290c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b854a846-e029-40c1-ac96-cc0f89011227", "AQAAAAEAACcQAAAAECZ9huxda8xTzcrIy0TtqrKEIADKCKYAGnDFFC6ziRdDtvy2GLYXJyfppLXlhcby1Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad5a6fe5-446a-4da0-8d2f-1748377fd45d", "AQAAAAEAACcQAAAAELqYIWIb7WfGZitI+qKxFPjM//1ZDBbV/d9vdT+t/Sreg+ddJR2Rnu+FykebrE4Lhw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a27543fa-887f-453d-964f-026909f869a7", "AQAAAAEAACcQAAAAEA7k9epmJok6BWXgLPMbd7eg4iwJ4z2RI7P8VmUOp9UqFaLik/49f3z9UTlaKJtyrA==" });
        }
    }
}
