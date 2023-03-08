using Microsoft.EntityFrameworkCore;
using StudentAttendance.Data.Entities.Groups;
using StudentAttendance.Data.Entities.Roles;
using StudentAttendance.Data.Entities.Students;
using StudentAttendance.Data.Entities.Users;

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

    public DbSet<UserDb> Users => Set<UserDb>();
    public DbSet<RoleDb> Roles => Set<RoleDb>();
    public DbSet<GroupDb> Groups => Set<GroupDb>();
    public DbSet<StudentDb> Students => Set<StudentDb>();
}