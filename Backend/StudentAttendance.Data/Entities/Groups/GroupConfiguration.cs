using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAttendance.Data.Entities.Groups;

public class GroupConfiguration : IEntityTypeConfiguration<GroupDbModel>
{
    public void Configure(EntityTypeBuilder<GroupDbModel> builder)
    {
        builder.HasKey(it => it.Id);
        builder.Property(it => it.GroupNumber)
            .HasMaxLength(10);

        builder.HasMany(it => it.Students)
            .WithOne(it => it.GroupDbModel)
            .HasForeignKey(it => it.GroupId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(it => it.Attendances)
            .WithOne(it => it.GroupDbModel)
            .HasForeignKey(it => it.GroupId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}