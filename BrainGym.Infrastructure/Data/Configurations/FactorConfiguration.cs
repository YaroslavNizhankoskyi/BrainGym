using BrainGym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Infrastructure.Data.Configurations
{
    internal class FactorConfiguration : EntityConfiguration<Factor>
    {
        public override void Configure(EntityTypeBuilder<Factor> builder)
        {
            builder.HasOne(x => x.Exercise)
                .WithMany(x => x.FactorRecommendations)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasOne(x => x.Recommendation)
                .WithMany(x => x.Factors)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
               

            base.Configure(builder);
        }
    }
}
