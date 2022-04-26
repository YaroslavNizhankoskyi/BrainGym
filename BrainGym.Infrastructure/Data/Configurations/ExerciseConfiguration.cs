using BrainGym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Infrastructure.Data.Configurations
{
    internal class ExerciseConfiguration : EntityConfiguration<Exercise>
    {
        public override void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasMany(x => x.FactorRecommendations)
                .WithOne(x => x.Exercise)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasMany(x => x.ExpectedResults)
               .WithOne(x => x.Exercise)
               .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasMany(x => x.Scores)
               .WithOne(x => x.Exercise)
               .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.Property(x => x.ExerciseMode)
                .IsRequired();

            builder.Property(x => x.ExerciseType)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(1024)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
