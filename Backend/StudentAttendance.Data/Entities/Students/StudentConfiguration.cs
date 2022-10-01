using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAttendance.Data.Entities.Students;

public class StudentConfiguration : IEntityTypeConfiguration<StudentDbModel>
{
    public void Configure(EntityTypeBuilder<StudentDbModel> builder)
    {
        builder.HasKey(it => it.Id);

        builder.Property(it => it.Name)
            .HasMaxLength(50);
    }
}