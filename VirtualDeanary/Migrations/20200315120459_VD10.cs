using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualDeanary.Migrations
{
    public partial class VD10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudyYear",
                table: "Semesters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudyYear",
                table: "Semesters");
        }
    }
}
