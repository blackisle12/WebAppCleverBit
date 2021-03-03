using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebAppCleverBit.Data.Entities;

namespace WebAppCleverBit.Data
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            for (var i = 1; i <= 10; i++)
            {
                builder.HasData(
                    new Match
                    {
                        MatchID = i,
                        ExpiryDate = DateTime.Now.AddHours(i)
                    });
            }
        }
    }
}
