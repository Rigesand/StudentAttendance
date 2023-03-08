using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAttendance.Data.Entities.Roles;

public class ConfigurationRole : IEntityTypeConfiguration<RoleDb>
{
    public void Configure(EntityTypeBuilder<RoleDb> builder)
    {
        builder.HasKey(it => it.Id);
    }
}