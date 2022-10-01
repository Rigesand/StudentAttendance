using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAttendance.Data.Entities.Lessons;

public class LessonConfiguration : IEntityTypeConfiguration<LessonDbModel>
{
    public void Configure(EntityTypeBuilder<LessonDbModel> builder)
    {
        builder.HasKey(it => it.Id);

        builder.Property(it => it.Title)
            .HasMaxLength(50);

        builder.HasMany(it => it.Attendances)
            .WithOne(it => it.Lesson)
            .HasForeignKey(it => it.LessonId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}