using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeCompany.DB.Migrations
{
    public partial class CompanySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_company",
                columns: new[] { "uuid", "CompanyName", "created_at", "created_by", "edited_at", "edited_by" },
                values: new object[] { "13ad310c-d2bd-4c77-a9d4-5a4a9bb2323c", "MilliPixel", new DateTime(2020, 12, 17, 16, 54, 37, 199, DateTimeKind.Local).AddTicks(578), "migration", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_company",
                keyColumn: "uuid",
                keyValue: "13ad310c-d2bd-4c77-a9d4-5a4a9bb2323c");
        }
    }
}
