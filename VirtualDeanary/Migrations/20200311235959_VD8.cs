using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualDeanary.Migrations
{
    public partial class VD8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_Faculties_FacultyId",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "FaacultyId",
                table: "Semesters");

            migrationBuilder.AlterColumn<int>(
                name: "FacultyId",
                table: "Semesters",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_Faculties_FacultyId",
                table: "Semesters",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_Faculties_FacultyId",
                table: "Semesters");

            migrationBuilder.AlterColumn<int>(
                name: "FacultyId",
                table: "Semesters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "FaacultyId",
                table: "Semesters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_Faculties_FacultyId",
                table: "Semesters",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
