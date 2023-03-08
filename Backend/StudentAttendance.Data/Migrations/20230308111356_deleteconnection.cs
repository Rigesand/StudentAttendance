using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendance.Data.Migrations
{
    public partial class deleteconnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleDbId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleDbId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleDbId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoleDbId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleDbId",
                table: "Users",
                column: "RoleDbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleDbId",
                table: "Users",
                column: "RoleDbId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
