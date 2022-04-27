using BrainGym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Domain
{
    public class ExpectedResult : Entity
    {
        public Guid ExerciseId { get; set; }
        public Guid RecommendationId { get; set; }
        public double Value { get; set; }
        public Recommendation Recommendation { get; set; }
        public Exercise Exercise { get; set; }
    }
}
