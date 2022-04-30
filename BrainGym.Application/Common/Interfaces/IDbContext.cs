using BrainGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Common.Interfaces
{
    public interface IDbContext
    {
        public IEnumerable<Score> Scores { get; set; }

        public IEnumerable<ExpectedResult> ExpectedResults { get; set; }

        public IEnumerable<Factor> FactorRecommendations { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
