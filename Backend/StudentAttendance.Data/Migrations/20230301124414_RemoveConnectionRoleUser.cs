using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendance.Data.Migrations
{
    public partial class RemoveConnectionRoleUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleDbModelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleDbModelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleDbModelId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoleDbModelId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleDbModelId",
                table: "Users",
                column: "RoleDbModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleDbModelId",
                table: "Users",
                column: "RoleDbModelId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
