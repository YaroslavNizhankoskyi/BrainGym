using BrainGym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Infrastructure.Data.Configurations
{
    internal class ScoreConfiguration : EntityConfiguration<Score>
    {
        public override void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.HasOne(x => x.Exercise)
                .WithMany(x => x.Scores)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Scores)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.Property(x => x.GameScore)
                .IsRequired();

            builder.Property(x => x.HealthFactor)
                .IsRequired();

            builder.Property(x => x.SleepFactor)
                .IsRequired();

            builder.Property(x => x.MentalFactor)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
