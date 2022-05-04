using AutoMapper;
using BrainGym.Application.Calls.Scores.Queries;
using BrainGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Common.Mappers
{
    public class ScoreProfile : Profile
    {
        public ScoreProfile()
        {
            CreateMap<Score, ScoreDto>()
                .ForMember(x => x.ExerciseName, src => src.MapFrom(x => x.Exercise.Name))
                .ForMember(x => x.UserName, src => src.MapFrom(x => x.User.FirstName));
        }
    }
}
