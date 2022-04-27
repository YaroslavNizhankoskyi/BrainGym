using BrainGym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Domain
{
    public class Exercise : Entity
    {
        public string Name { get; set; }

        public ExerciseType ExerciseType { get; set; }

        public ExerciseMode ExerciseMode { get; set; }

        public string Description { get; set; }

        public string GameData { get; set; }

        public ICollection<Factor> FactorRecommendations { get; set; }

        public ICollection<ExpectedResult> ExpectedResults { get; set; }

        public ICollection<Score> Scores { get; set; }
    }
}

namespace BrainGym.Domain
{
    public enum ExerciseType
    {
        Math = 0,
        Memory = 1,
        Logic = 2,
        Speed = 3
    }

    public enum ExerciseMode
    {
        Easy = 0,
        Medium = 1,
        Hard = 2,
    }
}