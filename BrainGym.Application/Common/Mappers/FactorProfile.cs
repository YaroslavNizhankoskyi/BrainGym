using AutoMapper;
using BrainGym.Application.Calls.Factors.Queries;
using BrainGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Common.Mappers
{
    public class FactorProfile : Profile
    {
        public FactorProfile()
        {
            CreateMap<Factor, FactorDto>()
                .ForMember(x => x.RecommendationText, src => src.MapFrom(x => x.Recommendation.Text))
                .ForMember(x => x.ExerciseName, src => src.MapFrom(x => x.Exercise.Name));
        }
    }
}
