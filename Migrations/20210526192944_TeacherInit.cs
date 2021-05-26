using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class TeacherInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeachersInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    teaPrefix = table.Column<string>(type: "TEXT", nullable: true),
                    teaFirstName = table.Column<string>(type: "TEXT", nullable: true),
                    teaLastName = table.Column<string>(type: "TEXT", nullable: true),
                    teaAge = table.Column<int>(type: "INTEGER", nullable: false),
                    teaDaySubject = table.Column<string>(type: "TEXT", nullable: true),
                    teaOptionalLang = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeachersInfos");
        }
    }
}
