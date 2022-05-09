using AutoMapper;
using BrainGym.Application.Calls.Exercises.Queries.Get;
using BrainGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Common.Mappers
{
    public class ExerciseProfile : Profile 
    {
        public ExerciseProfile()
        {
            CreateMap<Exercise, ExerciseDto>();
        }
    }
}
