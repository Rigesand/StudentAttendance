using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAttendance.Data.Entities.RefreshTokens;

namespace StudentAttendance.Data.Entities.Users;

public class UserConfiguration : IEntityTypeConfiguration<UserDbModel>
{
    public void Configure(EntityTypeBuilder<UserDbModel> builder)
    {
        builder.HasKey(it => it.Id);

        builder.HasOne(it => it.RefreshToken)
            .WithOne(it => it.User)
            .HasForeignKey<RefreshTokenDbModel>(it => it.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}