using BrainGym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Domain
{
    public class FactorRecommendation : Entity
    {
        public FactorType FactorType { get; set; }

        public string Recommendation { get; set; }

        public Guid ExerciseId { get; set; }

        public Exercise Exercise { get; set; }
    }

    public enum FactorType
    {
        Sleep = 0,
        Health = 1,
        Mental = 2
    }
}
