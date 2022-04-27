using BrainGym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Infrastructure.Data.Configurations
{
    internal class RecommendationConfiguration : EntityConfiguration<Recommendation>
    {
        public override void Configure(EntityTypeBuilder<Recommendation> builder)
        {
            builder.Property(x => x.Text)
                .HasMaxLength(256);

            base.Configure(builder);
        }
    }
}
