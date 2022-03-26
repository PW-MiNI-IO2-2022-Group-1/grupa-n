using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinationSystem.Data.Migrations
{
    public partial class MovedPesel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1076fe7-abf6-420d-8810-6cb0f3a92f6a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1076fe7-abf6-420d-8810-6cb0f3a92f6a");

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

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LicenceId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd", 0, "3e973c68-c2f9-4000-b586-e0743dbd13c5", "Administrator", "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEPBGW/Zz6oqHBY4a28iHrxSrxFUH/4+iHlhSmTAmrE6oEFjpyDD6EWty/pFoIK/MMg==", null, false, "7eba0b8e-69f0-424a-b309-73ce758f3205", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LicenceId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", 0, "6e71819a-e7f6-4d53-a11e-b50574af7ebe", "Doctor", "doctor@localhost.com", true, "Default", "Doctor", -1, false, null, "DOCTOR@LOCALHOST.COM", "DOCTOR@LOCALHOST.COM", "AQAAAAEAACcQAAAAELAkVDzvBljvSYcbrJ0b+gssUBWL8m38W434YrHlQrhTQDvjlLhqi2Y3gPFD+i+a/A==", null, false, "3f88f172-8ed2-4552-895f-fcdf6e13f4d9", false, "doctor@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Pesel", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", 0, "5ba179de-fa7b-405a-8179-680bc755f1e3", "Patient", "patient@localhost.com", true, "Default", "Patient", false, null, "PATIENT@LOCALHOST.COM", "PATIENT@LOCALHOST.COM", "AQAAAAEAACcQAAAAEK637eNajfOajPTHXrNCt7c6QnifwUZWm/LECP0/pESRSZzdoFNDd52gWPh5U8LwcQ==", "12345678901", null, false, "c427f190-f1d1-4b64-938e-7679bd084ee4", false, "patient@localhost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LicenceId",
                table: "AspNetUsers");

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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "410adff7-f581-4737-b4d6-0dc9a88dec59",
                column: "ConcurrencyStamp",
                value: "b2c90031-bce9-45ca-bf67-2deacf79d5d9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53716615-3a3b-4948-9d28-8076bf328b4a",
                column: "ConcurrencyStamp",
                value: "4b7a0461-b2f3-458a-a456-b13fa20558b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8076fe7-faf6-757b-3452-6aa5f7a33c6c",
                column: "ConcurrencyStamp",
                value: "e2513254-160c-4d0d-93ee-8ab2c35dbce1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e62890a1-0cf9-4116-9a0d-ee71854fb622", "AQAAAAEAACcQAAAAEBtY00HNqCFz8u4TcebBpHt4/MYawBX0Ltg++NI7fDVxWUkYnvPOPhP7zYmmfifgCg==", "91fd09c1-e796-4be3-9768-57d6fd4c7113" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Pesel", "SecurityStamp" },
                values: new object[] { "b098ba4c-4db0-48b7-b53d-8e595ac22b01", "AQAAAAEAACcQAAAAECdSys245sWY2hoJUNuZydOoeL3D85wEJRC4wZ7X96k+Ahk5xx8GMSK0BOQ7PDQ+qw==", null, "7228fd06-cb72-4f29-ba56-1655436eda75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2265d747-d21e-4e57-89ed-7f054d973f4d", "AQAAAAEAACcQAAAAEHMkw1smj/AC85COzTyOjssTF/EyI/SDV+QxeZk6kY/tEEmYo9KmKCjAIGadw/eZvQ==", "203ea25d-4d9c-49d4-8a61-7ea2994fc307" });
        }
    }
}
