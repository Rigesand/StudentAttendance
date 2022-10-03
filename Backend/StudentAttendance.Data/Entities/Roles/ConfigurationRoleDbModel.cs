using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAttendance.Data.Entities.Roles;

public class ConfigurationRoleDbModel : IEntityTypeConfiguration<RoleDbModel>
{
    public void Configure(EntityTypeBuilder<RoleDbModel> builder)
    {
        builder.HasKey(it => it.Id);
        builder.HasMany(it => it.Users)
            .WithOne(it => it.Role)
            .HasForeignKey(it => it.RoleId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}