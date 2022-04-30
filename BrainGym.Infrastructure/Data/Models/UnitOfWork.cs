using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using BrainGym.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Infrastructure.Data.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;

        public IDbRepository<User> users;
        public IDbRepository<Exercise> exercises;
        public IDbRepository<Recommendation> recommendations;
        public IDbRepository<ExpectedResult> expectedResults;
        public IDbRepository<Factor> factors;
        public IDbRepository<Score> scores;

        public IDbRepository<User> Users
        {
            get
            {
                return users ?? (users = new DbRepository<User>(_context));
            }
        }


        public IDbRepository<Score> Scores
        {
            get
            {
                return scores ?? (scores = new DbRepository<Score>(_context));
            }
        }

        public IDbRepository<ExpectedResult> ExpectedResults
        {
            get
            {
                return expectedResults ?? (expectedResults = new DbRepository<ExpectedResult>(_context));
            }
        }

        public IDbRepository<Recommendation> Recommendations
        {
            get
            {
                return recommendations ?? (recommendations = new DbRepository<Recommendation>(_context));
            }
        }

        public IDbRepository<Factor> Factors
        {
            get
            {
                return factors ?? (factors = new DbRepository<Factor>(_context));
            }
        }

        public IDbRepository<Exercise> Exercises
        {
            get
            {
                return exercises ?? (exercises = new DbRepository<Exercise>(_context));
            }
        }

        public UnitOfWork(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Complete()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
