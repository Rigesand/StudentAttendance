using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendance.Data.Migrations
{
    public partial class AddEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupDbModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupDbModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonDbModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonDbModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentDbModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDbModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDbModel_GroupDbModel_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GroupDbModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_LessonDbModel_LessonId",
                        column: x => x.LessonId,
                        principalTable: "LessonDbModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VisitedStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitedStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitedStudents_Attendances_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "Attendances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VisitedStudents_StudentDbModel_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentDbModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_LessonId",
                table: "Attendances",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDbModel_GroupId",
                table: "StudentDbModel",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitedStudents_AttendanceId",
                table: "VisitedStudents",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitedStudents_StudentId",
                table: "VisitedStudents",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitedStudents");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "StudentDbModel");

            migrationBuilder.DropTable(
                name: "LessonDbModel");

            migrationBuilder.DropTable(
                name: "GroupDbModel");
        }
    }
}
