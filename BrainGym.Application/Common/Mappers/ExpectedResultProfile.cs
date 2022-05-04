using AutoMapper;
using BrainGym.Application.Calls.ExpectedResults.Queries;
using BrainGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Common.Mappers
{
    public class ExpectedResultProfile : Profile 
    {
        public ExpectedResultProfile()
        {
            CreateMap<ExpectedResult, ExpectedResultDto>()
                .ForMember(x => x.ExerciseName, src => src.MapFrom(x => x.Exercise.Name))
                .ForMember(x => x.RecommendationText, src => src.MapFrom(x => x.Recommendation.Text));
        }
    }
}
