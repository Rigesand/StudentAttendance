using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAttendance.Data.Entities.Attendances;

public class AttendanceConfiguration : IEntityTypeConfiguration<AttendanceDbModel>
{
    public void Configure(EntityTypeBuilder<AttendanceDbModel> builder)
    {
        builder.HasKey(it => it.Id);

        builder.HasMany(it => it.VisitedStudents)
            .WithOne(it => it.Attendance)
            .HasForeignKey(it => it.AttendanceId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}