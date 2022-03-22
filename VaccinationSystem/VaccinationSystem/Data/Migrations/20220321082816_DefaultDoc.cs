using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinationSystem.Data.Migrations
{
    public partial class DefaultDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "410adff7-f581-4737-b4d6-0dc9a88dec59",
                column: "ConcurrencyStamp",
                value: "8df9dc84-8cdf-419e-bd1c-9ef61c2e1a07");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53716615-3a3b-4948-9d28-8076bf328b4a",
                column: "ConcurrencyStamp",
                value: "0e598312-efc8-4772-9d94-9995a870329e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8076fe7-faf6-757b-3452-6aa5f7a33c6c",
                column: "ConcurrencyStamp",
                value: "abd892d0-fade-4365-b067-5573119238c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3afcb550-0e3d-42f3-8a35-9aeef3d5f082", "AQAAAAEAACcQAAAAELu+DVtgVhOnyL5nWxnzm48ta8r1fEPZnwArFPr8e5HfPpmhM28eRV5RVtZ0b0dTQg==", "ab158651-dda0-4405-b77d-0baadbc1e7d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe25f980-fde1-44ab-a121-e3d0acddddc7", "AQAAAAEAACcQAAAAEI2z4sgREImddmI07G7COG6rpzR6DBVy9bGr+HSBUTdnkcb5LsKV4PHjqlfCK5FA2A==", "169cf130-b7f3-4383-a406-7520e10afc2d" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Pesel", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", 0, "830a5602-06bd-4620-a7e4-febb8f882d18", "doctor@localhost.com", true, "Default", "Doctor", false, null, "DOCTOR@LOCALHOST.COM", "DOCTOR@LOCALHOST.COM", "AQAAAAEAACcQAAAAEA6sfwIHKnUyCjaWOqKAVwG5ox565ElPuJQEChYWhTEdKpfrkT9c+MUTTegrh1qrrQ==", null, null, false, "6d87901d-36a9-49b4-b27f-6e636c49e6bf", false, "doctor@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "53716615-3a3b-4948-9d28-8076bf328b4a", "f1076fe7-abf6-420d-8810-6cb0f3a92f6a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "53716615-3a3b-4948-9d28-8076bf328b4a", "f1076fe7-abf6-420d-8810-6cb0f3a92f6a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1076fe7-abf6-420d-8810-6cb0f3a92f6a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "410adff7-f581-4737-b4d6-0dc9a88dec59",
                column: "ConcurrencyStamp",
                value: "ac6c2ced-c96a-4351-8676-147ef2560bb0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53716615-3a3b-4948-9d28-8076bf328b4a",
                column: "ConcurrencyStamp",
                value: "2c4650f2-c517-4e0e-b5e1-6c843304e403");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8076fe7-faf6-757b-3452-6aa5f7a33c6c",
                column: "ConcurrencyStamp",
                value: "0cd3a2db-d4a9-46ab-8586-bd0d8a19920e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6ab64a2-5720-41b5-ac14-72cc8cc083ab", "AQAAAAEAACcQAAAAEOXgehtXg2z7si9uryfypiIFYIMjxgGCVLcfdtGShnqBshErBqF0OcTx5wT9T6w++w==", "47748950-b61a-48eb-a9a4-09ad909f44c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "283d5fcd-210d-4f52-97dc-8313a1cc5189", "AQAAAAEAACcQAAAAEFN0BzRuxW7lx8+ZVL9imjGn2SjZucjLxhDo6IlGEi74s8lDQOd7t/4iu/qNU9a1Lg==", "22cf15fb-e933-45f9-891d-cf239b2f2bf9" });
        }
    }
}
