using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinationSystem.Data.Migrations
{
    public partial class RolesAndDefaultUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Pesel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "410adff7-f581-4737-b4d6-0dc9a88dec59", "ac6c2ced-c96a-4351-8676-147ef2560bb0", "Patient", "PATIENT" },
                    { "53716615-3a3b-4948-9d28-8076bf328b4a", "2c4650f2-c517-4e0e-b5e1-6c843304e403", "Doctor", "DOCTOR" },
                    { "c8076fe7-faf6-757b-3452-6aa5f7a33c6c", "0cd3a2db-d4a9-46ab-8586-bd0d8a19920e", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Pesel", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd", 0, "d6ab64a2-5720-41b5-ac14-72cc8cc083ab", "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEOXgehtXg2z7si9uryfypiIFYIMjxgGCVLcfdtGShnqBshErBqF0OcTx5wT9T6w++w==", null, null, false, "47748950-b61a-48eb-a9a4-09ad909f44c0", false, "admin@localhost.com" },
                    { "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 0, "283d5fcd-210d-4f52-97dc-8313a1cc5189", "patient@localhost.com", true, "Default", "Patient", false, null, "PATIENT@LOCALHOST.COM", "PATIENT@LOCALHOST.COM", "AQAAAAEAACcQAAAAEFN0BzRuxW7lx8+ZVL9imjGn2SjZucjLxhDo6IlGEi74s8lDQOd7t/4iu/qNU9a1Lg==", null, null, false, "22cf15fb-e933-45f9-891d-cf239b2f2bf9", false, "patient@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c8076fe7-faf6-757b-3452-6aa5f7a33c6c", "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "410adff7-f581-4737-b4d6-0dc9a88dec59", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53716615-3a3b-4948-9d28-8076bf328b4a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c8076fe7-faf6-757b-3452-6aa5f7a33c6c", "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "410adff7-f581-4737-b4d6-0dc9a88dec59", "c1076fe7-abf6-420d-8810-6cb0f3a92f6a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "410adff7-f581-4737-b4d6-0dc9a88dec59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8076fe7-faf6-757b-3452-6aa5f7a33c6c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1076fe7-abf6-420d-8810-6cb0f3a92f6a");

            migrationBuilder.AlterColumn<string>(
                name: "Pesel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
