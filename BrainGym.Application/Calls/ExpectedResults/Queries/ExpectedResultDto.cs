using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.ExpectedResults.Queries
{
    public class ExpectedResultDto
    {
        public string RecommendationText { get; set; }
        public string ExerciseName { get; set; }
        public Guid ExerciseId { get; set; }
        public Guid RecommendationId { get; set; }
        public double Value { get; set; }
    }
}
