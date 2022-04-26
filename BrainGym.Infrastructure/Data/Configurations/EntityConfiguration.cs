using BrainGym.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Infrastructure.Data.Configurations
{
    internal class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IDeletable, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(e => e.IsDeleted).IsRequired();
        }
    }
}
