using BrainGym.Domain;
using BrainGym.Domain.Common;
using BrainGym.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrainGym.Infrastructure.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Score> Scores { get; set; }

        public DbSet<ExpectedResult> ExpectedResults { get; set; }

        public DbSet<FactorRecommendation> FactorRecommendations { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public AppDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var domainAssembly = Assembly.Load("BrainGym.Domain");
            var softDeletableEntities = domainAssembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(Entity)));

            foreach (var entityType in softDeletableEntities)
            {
                typeof(AppDbContext)
                .GetMethod("MakeSoftDeletable")
                ?.MakeGenericMethod(entityType)
                .Invoke(this, new object[] { modelBuilder });
            }

            base.OnModelCreating(modelBuilder);
        }

        public void MakeSoftDeletable<T>(ModelBuilder modelBuilder) where T : class, IDeletable
        {
            modelBuilder.Entity<T>()
                .HasQueryFilter(p => !p.IsDeleted)
                .Property(e => e.IsDeleted);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<IDeletable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.IsDeleted = false;
                        break;

                    case EntityState.Modified:
                        break;

                    case EntityState.Deleted:
                        entry.Entity.IsDeleted = true;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
