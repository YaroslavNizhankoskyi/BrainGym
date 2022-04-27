using BrainGym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Domain
{
    public class Factor : Entity
    {
        public FactorType FactorType { get; set; }

        public Guid RecommendationId { get; set; }

        public Guid ExerciseId { get; set; }

        public double Coefficient { get; set; }

        public Exercise Exercise { get; set; }

        public Recommendation Recommendation { get; set; }
    }

    public enum FactorType
    {
        Sleep = 0,
        Health = 1,
        Mental = 2
    }
}
