﻿using BrainGym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Infrastructure.Data.Configurations
{
    internal class FactorRecommendationConfiguration : EntityConfiguration<FactorRecommendation>
    {
        public override void Configure(EntityTypeBuilder<FactorRecommendation> builder)
        {
            builder.HasOne(x => x.Exercise)
                .WithMany(x => x.FactorRecommendations)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.Property(x => x.Recommendation)
                .HasMaxLength(256)
                .IsRequired();
                

            base.Configure(builder);
        }
    }
}