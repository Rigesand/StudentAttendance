using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendance.Data.Migrations
{
    public partial class RefreshEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_LessonDbModel_LessonId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentDbModel_GroupDbModel_GroupId",
                table: "StudentDbModel");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitedStudents_StudentDbModel_StudentId",
                table: "VisitedStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentDbModel",
                table: "StudentDbModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonDbModel",
                table: "LessonDbModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupDbModel",
                table: "GroupDbModel");

            migrationBuilder.RenameTable(
                name: "StudentDbModel",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "LessonDbModel",
                newName: "Lessons");

            migrationBuilder.RenameTable(
                name: "GroupDbModel",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_StudentDbModel_GroupId",
                table: "Students",
                newName: "IX_Students_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Lessons_LessonId",
                table: "Attendances",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitedStudents_Students_StudentId",
                table: "VisitedStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Lessons_LessonId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitedStudents_Students_StudentId",
                table: "VisitedStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "StudentDbModel");

            migrationBuilder.RenameTable(
                name: "Lessons",
                newName: "LessonDbModel");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "GroupDbModel");

            migrationBuilder.RenameIndex(
                name: "IX_Students_GroupId",
                table: "StudentDbModel",
                newName: "IX_StudentDbModel_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentDbModel",
                table: "StudentDbModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonDbModel",
                table: "LessonDbModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupDbModel",
                table: "GroupDbModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_LessonDbModel_LessonId",
                table: "Attendances",
                column: "LessonId",
                principalTable: "LessonDbModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentDbModel_GroupDbModel_GroupId",
                table: "StudentDbModel",
                column: "GroupId",
                principalTable: "GroupDbModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitedStudents_StudentDbModel_StudentId",
                table: "VisitedStudents",
                column: "StudentId",
                principalTable: "StudentDbModel",
                principalColumn: "Id");
        }
    }
}
