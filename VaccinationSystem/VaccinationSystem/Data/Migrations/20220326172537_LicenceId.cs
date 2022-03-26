using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinationSystem.Data.Migrations
{
    public partial class LicenceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b098ba4c-4db0-48b7-b53d-8e595ac22b01", "AQAAAAEAACcQAAAAECdSys245sWY2hoJUNuZydOoeL3D85wEJRC4wZ7X96k+Ahk5xx8GMSK0BOQ7PDQ+qw==", "7228fd06-cb72-4f29-ba56-1655436eda75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2265d747-d21e-4e57-89ed-7f054d973f4d", "AQAAAAEAACcQAAAAEHMkw1smj/AC85COzTyOjssTF/EyI/SDV+QxeZk6kY/tEEmYo9KmKCjAIGadw/eZvQ==", "203ea25d-4d9c-49d4-8a61-7ea2994fc307" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "830a5602-06bd-4620-a7e4-febb8f882d18", "AQAAAAEAACcQAAAAEA6sfwIHKnUyCjaWOqKAVwG5ox565ElPuJQEChYWhTEdKpfrkT9c+MUTTegrh1qrrQ==", "6d87901d-36a9-49b4-b27f-6e636c49e6bf" });
        }
    }
}
