using AutoMapper;
using BrainGym.Application.Calls.Recommendations.Queries;
using BrainGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Common.Mappers
{
    public class RecommendationProfile : Profile
    {
        public RecommendationProfile()
        {
            CreateMap<Recommendation, RecommendationDto>();
        }
    }
}
