using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualDeanary.Migrations
{
    public partial class VD12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SemesterName",
                table: "Semesters");

            migrationBuilder.AlterColumn<int>(
                name: "Degree",
                table: "Semesters",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "Semesters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "Semesters");

            migrationBuilder.AlterColumn<string>(
                name: "Degree",
                table: "Semesters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "SemesterName",
                table: "Semesters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
