﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendance.Data.Migrations
{
    public partial class Addforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVisited",
                table: "VisitedStudents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Attendances",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_GroupId",
                table: "Attendances",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Groups_GroupId",
                table: "Attendances",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Groups_GroupId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_GroupId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "IsVisited",
                table: "VisitedStudents");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Attendances");
        }
    }
}
