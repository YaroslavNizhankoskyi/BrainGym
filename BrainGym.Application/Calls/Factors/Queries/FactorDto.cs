using BrainGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Factors.Queries
{
    public class FactorDto
    {
        public string RecommendationText { get; set; }

        public string ExerciseName { get; set; }

        public FactorType FactorType { get; set; }

        public Guid RecommendationId { get; set; }

        public Guid ExerciseId { get; set; }

        public double Coefficient { get; set; }
    }
}
