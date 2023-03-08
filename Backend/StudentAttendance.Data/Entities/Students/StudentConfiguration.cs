using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAttendance.Data.Entities.Students;

public class StudentConfiguration : IEntityTypeConfiguration<StudentDb>
{
    public void Configure(EntityTypeBuilder<StudentDb> builder)
    {
        builder.HasKey(it => it.Id);

        builder.Property(it => it.Name)
            .HasMaxLength(50);
    }
}