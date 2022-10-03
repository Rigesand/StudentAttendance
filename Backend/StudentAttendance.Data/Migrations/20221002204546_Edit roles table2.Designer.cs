﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentAttendance.Data;

#nullable disable

namespace StudentAttendance.Data.Migrations
{
    [DbContext(typeof(StudentAttendanceDbContext))]
    [Migration("20221002204546_Edit roles table2")]
    partial class Editrolestable2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StudentAttendance.Data.Entities.Attendances.AttendanceDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("LessonId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Groups.GroupDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GroupNumber")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Lessons.LessonDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.RefreshTokens.RefreshTokenDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("AddedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("ExpiryDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsRevorked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("JwtId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Roles.RoleDbModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Students.StudentDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Users.UserDbModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.VisitedStudents.VisitedStudentDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AttendanceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsVisited")
                        .HasColumnType("bit");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AttendanceId");

                    b.HasIndex("StudentId");

                    b.ToTable("VisitedStudents");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Attendances.AttendanceDbModel", b =>
                {
                    b.HasOne("StudentAttendance.Data.Entities.Groups.GroupDbModel", "GroupDbModel")
                        .WithMany("Attendances")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StudentAttendance.Data.Entities.Lessons.LessonDbModel", "Lesson")
                        .WithMany("Attendances")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("GroupDbModel");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.RefreshTokens.RefreshTokenDbModel", b =>
                {
                    b.HasOne("StudentAttendance.Data.Entities.Users.UserDbModel", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("StudentAttendance.Data.Entities.RefreshTokens.RefreshTokenDbModel", "UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Students.StudentDbModel", b =>
                {
                    b.HasOne("StudentAttendance.Data.Entities.Groups.GroupDbModel", "GroupDbModel")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("GroupDbModel");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Users.UserDbModel", b =>
                {
                    b.HasOne("StudentAttendance.Data.Entities.Roles.RoleDbModel", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.VisitedStudents.VisitedStudentDbModel", b =>
                {
                    b.HasOne("StudentAttendance.Data.Entities.Attendances.AttendanceDbModel", "Attendance")
                        .WithMany("VisitedStudents")
                        .HasForeignKey("AttendanceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StudentAttendance.Data.Entities.Students.StudentDbModel", "Student")
                        .WithMany("VisitedStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Attendance");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Attendances.AttendanceDbModel", b =>
                {
                    b.Navigation("VisitedStudents");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Groups.GroupDbModel", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Lessons.LessonDbModel", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Roles.RoleDbModel", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Students.StudentDbModel", b =>
                {
                    b.Navigation("VisitedStudents");
                });

            modelBuilder.Entity("StudentAttendance.Data.Entities.Users.UserDbModel", b =>
                {
                    b.Navigation("RefreshToken");
                });
#pragma warning restore 612, 618
        }
    }
}