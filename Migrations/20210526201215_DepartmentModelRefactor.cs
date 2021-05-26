using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class DepartmentModelRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeachersInfos_DepartmentInfos_DepartmentInfoId",
                table: "TeachersInfos");

            migrationBuilder.DropIndex(
                name: "IX_TeachersInfos_DepartmentInfoId",
                table: "TeachersInfos");

            migrationBuilder.DropColumn(
                name: "DepartmentInfoId",
                table: "TeachersInfos");

            migrationBuilder.AddColumn<string>(
                name: "departmentID",
                table: "TeachersInfos",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "departmentID",
                table: "TeachersInfos");

            migrationBuilder.AddColumn<long>(
                name: "DepartmentInfoId",
                table: "TeachersInfos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeachersInfos_DepartmentInfoId",
                table: "TeachersInfos",
                column: "DepartmentInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersInfos_DepartmentInfos_DepartmentInfoId",
                table: "TeachersInfos",
                column: "DepartmentInfoId",
                principalTable: "DepartmentInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
