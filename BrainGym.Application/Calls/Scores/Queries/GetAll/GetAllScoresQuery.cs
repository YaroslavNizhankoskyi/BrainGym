using AutoMapper;
using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Scores.Queries.GetAll
{
    public class GetAllScoresQuery : IRequest<IQueryable<ScoreDto>>
    {

    }

    public class GetAllScoresQueryHandler : IRequestHandler<GetAllScoresQuery, IQueryable<ScoreDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllScoresQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<IQueryable<ScoreDto>> Handle(GetAllScoresQuery request, CancellationToken cancellationToken)
        {
            return _uow.Scores.ProjectTo<ScoreDto>(_mapper.ConfigurationProvider);
        }
    }
}
