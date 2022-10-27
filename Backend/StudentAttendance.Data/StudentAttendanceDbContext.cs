using Microsoft.EntityFrameworkCore;
using StudentAttendance.Data.Entities.Attendances;
using StudentAttendance.Data.Entities.Groups;
using StudentAttendance.Data.Entities.Lessons;
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

    public DbSet<AttendanceDbModel> Attendances => Set<AttendanceDbModel>();
    public DbSet<VisitedStudentDbModel> VisitedStudents => Set<VisitedStudentDbModel>();
    public DbSet<LessonDbModel> Lessons => Set<LessonDbModel>();
    public DbSet<GroupDbModel> Groups => Set<GroupDbModel>();
    public DbSet<StudentDbModel> Students => Set<StudentDbModel>();
    public DbSet<UserDbModel> Users => Set<UserDbModel>();
    public DbSet<RoleDbModel> Roles => Set<RoleDbModel>();
}