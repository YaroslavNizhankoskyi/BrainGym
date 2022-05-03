using BrainGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Exercises.Queries.Get
{
    public class ExerciseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public ExerciseMode ExerciseMode { get; set; }

        public ExerciseType ExerciseType { get; set; }

        public string GameData { get; set; }
    }
}
