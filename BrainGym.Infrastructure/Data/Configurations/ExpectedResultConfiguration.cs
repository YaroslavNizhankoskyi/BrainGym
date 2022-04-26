using BrainGym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Infrastructure.Data.Configurations
{
    internal class ExpectedResultConfiguration : EntityConfiguration<ExpectedResult>
    {
                
        public override void Configure(EntityTypeBuilder<ExpectedResult> builder)
        {
            builder.HasOne(x => x.Exercise)
                .WithMany(x => x.ExpectedResults)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.Property(x => x.Value)
                .IsRequired();

            builder.Property(x => x.Recommendation)
                .HasMaxLength(256)
                .IsRequired(); ;

            base.Configure(builder);
        }
    }
}
