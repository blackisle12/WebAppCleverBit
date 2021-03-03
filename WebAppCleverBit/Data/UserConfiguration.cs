using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebAppCleverBit.Common;
using WebAppCleverBit.Data.Entities;

namespace WebAppCleverBit.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
                new ApplicationUser
                {
                    Id = StringConstants.USER_1_ID,
                    UserName = StringConstants.USER_1_USERNAME,
                    NormalizedUserName = StringConstants.USER_1_USERNAME.ToUpper(),
                    PasswordHash = StringConstants.USER_1_PASSWORD_HASH,
                    Email = StringConstants.USER_1_EMAIL,
                    NormalizedEmail = StringConstants.USER_1_EMAIL.ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = new Guid().ToString("D"),
                    ConcurrencyStamp = StringConstants.USER_1_CONCURRENCY_STAMP
                },
                new ApplicationUser
                {
                    Id = StringConstants.USER_2_ID,
                    UserName = StringConstants.USER_2_USERNAME,
                    NormalizedUserName = StringConstants.USER_2_USERNAME.ToUpper(),
                    PasswordHash = StringConstants.USER_2_PASSWORD_HASH,
                    Email = StringConstants.USER_2_EMAIL,
                    NormalizedEmail = StringConstants.USER_2_EMAIL.ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = new Guid().ToString("D"),
                    ConcurrencyStamp = StringConstants.USER_2_CONCURRENCY_STAMP
                });
        }
    }
}
