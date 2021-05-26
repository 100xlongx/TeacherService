using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class NewDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DepartmentInfoId",
                table: "TeachersInfos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DepartmentInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "scheduleInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studentId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scheduleInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_scheduleInfos_StudentsInfo_studentId",
                        column: x => x.studentId,
                        principalTable: "StudentsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "classInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    teacherId = table.Column<long>(type: "INTEGER", nullable: true),
                    departmentId = table.Column<long>(type: "INTEGER", nullable: true),
                    ScheduleInfoId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_classInfos_DepartmentInfos_departmentId",
                        column: x => x.departmentId,
                        principalTable: "DepartmentInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_classInfos_scheduleInfos_ScheduleInfoId",
                        column: x => x.ScheduleInfoId,
                        principalTable: "scheduleInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_classInfos_TeachersInfos_teacherId",
                        column: x => x.teacherId,
                        principalTable: "TeachersInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DepartmentInfos",
                column: "Id",
                value: 1L);

            migrationBuilder.InsertData(
                table: "DepartmentInfos",
                column: "Id",
                value: 2L);

            migrationBuilder.CreateIndex(
                name: "IX_TeachersInfos_DepartmentInfoId",
                table: "TeachersInfos",
                column: "DepartmentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_classInfos_departmentId",
                table: "classInfos",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_classInfos_ScheduleInfoId",
                table: "classInfos",
                column: "ScheduleInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_classInfos_teacherId",
                table: "classInfos",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_scheduleInfos_studentId",
                table: "scheduleInfos",
                column: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersInfos_DepartmentInfos_DepartmentInfoId",
                table: "TeachersInfos",
                column: "DepartmentInfoId",
                principalTable: "DepartmentInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeachersInfos_DepartmentInfos_DepartmentInfoId",
                table: "TeachersInfos");

            migrationBuilder.DropTable(
                name: "classInfos");

            migrationBuilder.DropTable(
                name: "DepartmentInfos");

            migrationBuilder.DropTable(
                name: "scheduleInfos");

            migrationBuilder.DropIndex(
                name: "IX_TeachersInfos_DepartmentInfoId",
                table: "TeachersInfos");

            migrationBuilder.DropColumn(
                name: "DepartmentInfoId",
                table: "TeachersInfos");
        }
    }
}
