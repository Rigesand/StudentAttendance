using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAttendance.Data.Entities.Groups;

public class GroupConfiguration : IEntityTypeConfiguration<GroupDb>
{
    public void Configure(EntityTypeBuilder<GroupDb> builder)
    {
        builder.HasKey(it => it.Id);
        builder.Property(it => it.GroupNumber)
            .HasMaxLength(10);

        builder.HasMany(it => it.Students)
            .WithOne(it => it.GroupDb)
            .HasForeignKey(it => it.GroupId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}