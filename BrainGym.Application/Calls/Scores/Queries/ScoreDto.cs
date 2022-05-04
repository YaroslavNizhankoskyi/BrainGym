using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Scores.Queries
{
    public class ScoreDto
    {
        public string UserName { get; set; }
        public string ExerciseName { get; set; }
        public Guid ExerciseId { get; set; }
        public Guid UserId { get; set; }
        public double GameScore { get; set; }
        public int MentalRate { get; set; }
        public int SleepRate { get; set; }
        public int HealthRate { get; set; }
    }
}
