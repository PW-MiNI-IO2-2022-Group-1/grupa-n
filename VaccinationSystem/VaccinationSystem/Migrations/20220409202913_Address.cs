using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinationSystem.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "HouseNumber", "LocalNumber", "Street", "ZipCode" },
                values: new object[] { -1, "Warszawa", "1", "", "plac Politechniki", "00-661" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "410adff7-f581-4737-b4d6-0dc9a88dec59",
                column: "ConcurrencyStamp",
                value: "69db5a35-5ec2-4ad3-8c05-f3dd36cf3e2a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53716615-3a3b-4948-9d28-8076bf328b4a",
                column: "ConcurrencyStamp",
                value: "df2769a3-a2b0-48c7-8f05-bf36205451f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8076fe7-faf6-757b-3452-6aa5f7a33c6c",
                column: "ConcurrencyStamp",
                value: "1bd3e2e0-2e2e-4c1d-afc9-c28a756f7479");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5c6ce05-e4f2-41a1-b057-7e3f7f1f6d48", "AQAAAAEAACcQAAAAEKr0/vx0hk7EVeYXHrxNQixZpg4zRMa759run7T1bKB8UCEsRiPbR9vQShgBv+3PZg==", "b893d85b-915d-45bb-a092-85758658bfe8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ee64026-11e2-41aa-a356-c60db30f9cc3", "AQAAAAEAACcQAAAAEBzrjEi5Dz+eNTEQPa4U593vIQ0S0ReHMjQX2yFK36k5qL3PxunKnBcETEN7SqiiNQ==", "93a58775-6cc1-4445-a582-74ff982ec36f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "AddressId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { -1, "79f0b26d-ea57-4ec4-9ff2-a96690d58063", "AQAAAAEAACcQAAAAEBWZBYAzkWFESbqsGOnUYrERfhBQoDijmNlv+yBup2l8NmeC1UBlBePhsihPS3BCeQ==", "70947d52-80b9-4705-95e7-8ce196ade721" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "410adff7-f581-4737-b4d6-0dc9a88dec59",
                column: "ConcurrencyStamp",
                value: "9998bfd3-2f9f-4d4e-8dad-6d53bbc56ddf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53716615-3a3b-4948-9d28-8076bf328b4a",
                column: "ConcurrencyStamp",
                value: "c03bf9db-52c1-48c2-a2e3-6a260e652e5f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8076fe7-faf6-757b-3452-6aa5f7a33c6c",
                column: "ConcurrencyStamp",
                value: "e58613c0-8678-4882-8e6a-03deceafc265");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f519299f-f152-4e3e-a90f-dedca73b62e4", "AQAAAAEAACcQAAAAEJitHv8MGaoALcRcrwWQ2S3rYmAhsa0nZqAwTs6o9wX98Hq5diRoIzMPrHLHGAuhEQ==", "8544e7ee-5914-462d-99ad-372618aaba1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bae9464-5879-44a5-8eaa-983e46e82a25", "AQAAAAEAACcQAAAAECR/ExJxRFZq/ZZBLRildV76GFX7MnJp1CmSZ9igkbX1ZoxUG8YyRl3CWzif1QVOxQ==", "01248651-b53d-4eac-9da5-a6c3493df6d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54b6cc8d-be75-42f7-91bf-d505eb10e525", "AQAAAAEAACcQAAAAEOed9q9vkTxFLVopQTdNiLBlysQDfu4D8OEtRSn5Il3Twdmx6xPy59hOCt7u+QFdpA==", "f4f68034-f39d-4608-9574-1adef98197e2" });
        }
    }
}
