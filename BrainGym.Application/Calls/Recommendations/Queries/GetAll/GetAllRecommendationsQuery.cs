using AutoMapper;
using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Recommendations.Queries.GetAll
{
    public class GetAllRecommendationsQuery : IRequest<IQueryable<RecommendationDto>>
    {
    }

    public class GetAllRecommendationsQueryHandler : IRequestHandler<GetAllRecommendationsQuery, IQueryable<RecommendationDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllRecommendationsQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<IQueryable<RecommendationDto>> Handle(GetAllRecommendationsQuery request, CancellationToken cancellationToken)
        {
            return _uow.Recommendations.ProjectTo<RecommendationDto>(_mapper.ConfigurationProvider);
        }
    }
}
