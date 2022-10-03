using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendance.Data.Migrations
{
    public partial class Editrolestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
