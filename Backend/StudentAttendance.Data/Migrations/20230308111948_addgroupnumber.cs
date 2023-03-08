using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendance.Data.Migrations
{
    public partial class addgroupnumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupNumber",
                table: "Users",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupNumber",
                table: "Users");
        }
    }
}
