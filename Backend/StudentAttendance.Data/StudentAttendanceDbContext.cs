using Microsoft.EntityFrameworkCore;
using StudentAttendance.Data.Entities.Attendances;
using StudentAttendance.Data.Entities.Groups;
using StudentAttendance.Data.Entities.Lessons;
using StudentAttendance.Data.Entities.RefreshTokens;
using StudentAttendance.Data.Entities.Roles;
using StudentAttendance.Data.Entities.Students;
using StudentAttendance.Data.Entities.Users;
using StudentAttendance.Data.Entities.VisitedStudents;

namespace StudentAttendance.Data;

public class StudentAttendanceDbContext : DbContext
{
    public StudentAttendanceDbContext(DbContextOptions<StudentAttendanceDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentAttendanceDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<AttendanceDbModel> Attendances { get; set; } = null!;
    public DbSet<VisitedStudentDbModel> VisitedStudents { get; set; } = null!;
    public DbSet<LessonDbModel> Lessons { get; set; } = null!;
    public DbSet<GroupDbModel> Groups { get; set; } = null!;
    public DbSet<StudentDbModel> Students { get; set; } = null!;
    public DbSet<RefreshTokenDbModel> RefreshTokens { get; set; } = null!;
    public DbSet<UserDbModel> Users { get; set; } = null!;
    public DbSet<RoleDbModel> Roles { get; set; } = null!;
}