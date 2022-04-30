using BrainGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Complete();
        public IDbRepository<User> Users { get; }
        public IDbRepository<Exercise> Exercises { get;}
        public IDbRepository<Recommendation> Recommendations { get;}
        public IDbRepository<ExpectedResult> ExpectedResults { get;}
        public IDbRepository<Factor> Factors { get;}
        public IDbRepository<Score> Scores { get;  }
    }
}
