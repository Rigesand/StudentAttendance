using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAttendance.Data.Entities.VisitedStudents;

public class VisitedStudentConfiguration : IEntityTypeConfiguration<VisitedStudentDbModel>
{
    public void Configure(EntityTypeBuilder<VisitedStudentDbModel> builder)
    {
        builder.HasKey(it => it.Id);
        builder.HasOne(it => it.Student)
            .WithMany(it => it.VisitedStudents)
            .HasForeignKey(it => it.StudentId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}