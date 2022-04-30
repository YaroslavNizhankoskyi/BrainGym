using BrainGym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Infrastructure.Data.Configurations
{
    internal class UserConfiguration : EntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.Scores)
                .WithOne(x => x.User)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.Property(x => x.UserId)
                .HasMaxLength(36);

            builder.Property(x => x.FirstName)
                .HasMaxLength(64);

            builder.Property(x => x.SecondName)
                .HasMaxLength(64);

            base.Configure(builder);
        }
    }
}
