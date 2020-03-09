using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualDeanary.Migrations
{
    public partial class VD4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Degree",
                table: "Groups",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Degree",
                table: "Groups",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
