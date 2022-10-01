using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAttendance.Data.Entities.RefreshTokens;

public class ConfigurationRefreshToken : IEntityTypeConfiguration<RefreshTokenDbModel>
{
    public void Configure(EntityTypeBuilder<RefreshTokenDbModel> builder)
    {
        builder.HasKey(it => it.Id);
    }
}