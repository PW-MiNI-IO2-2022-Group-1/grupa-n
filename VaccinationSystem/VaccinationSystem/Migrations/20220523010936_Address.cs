using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinationSystem.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "91b95b3f-8a32-4af8-9114-8a2e53618e21");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "ec2f8a1e-bb40-4474-a543-efcd66516141");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "38b68f03-ea11-41ce-8c05-1e33ab54ebed");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0fb9e762-0b4d-45f7-8818-fbad1d1e10fb", "AQAAAAEAACcQAAAAENCHcFGziPFcGK7IvcYvWJl9du5pu7aIPzdoRtKtnXFKy5QLrF0SyB4IJK33GFVrxA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "13cc49b7-a7b6-4010-b2af-f8115715e65a", "AQAAAAEAACcQAAAAEPAG+7D3gG8mzhyHHDD0ErUZXd+Us1bnaBx6RNMBr/xCC6jPSF82qB0XsN7CUgn/mA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1daa5280-9bf8-4503-8fbd-dd39e4d05947", "AQAAAAEAACcQAAAAEKQMQbZf8YQllLwWjXWHMNoA9UPlgtP5KerSKdGRRbRRayTB1gIYQRt2pxKagPuKgg==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LicenceId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { -22, 0, "21e38a20-1c9c-49f8-a3fe-014e5562801d", "Doctor", "testdoctor@localhost.com", true, "Test", "Doctor", "-22", false, null, "DOCTOR@LOCALHOST.COM", "DOCTOR@LOCALHOST.COM", "AQAAAAEAACcQAAAAEPZyfbdEuA4cR/1iJbRebWsDxoVTDLuWfEXRxoiut1x8yTQdDlSVBXE6/c94sg01sg==", null, false, "T4G4EBCXKGJUCPCGBAPXV7FMUMXNE464", false, "testdoctor@localhost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: -22);

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
