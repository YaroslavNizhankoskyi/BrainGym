using BrainGym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Domain
{
    public class Score : Entity
    {
        public Guid ExerciseId { get; set; } 
        public Guid UserId { get; set; }
        public double GameScore { get; set; }
        public int MentalFactor { get; set; }
        public int SleepFactor { get; set; }
        public int HealthFactor { get; set; }
        public Exercise Exercise { get; set; }
        public User User { get; set; }
    }
}
