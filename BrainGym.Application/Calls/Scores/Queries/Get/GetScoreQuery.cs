using AutoMapper;
using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Scores.Queries.Get
{
    public class GetScoreQuery : IRequest<ScoreDto>
    {
        public GetScoreQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }

    }

    public class GetScoreQueryHandler : IRequestHandler<GetScoreQuery, ScoreDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetScoreQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<ScoreDto> Handle(GetScoreQuery request, CancellationToken cancellationToken)
        {
            var score = await _uow.Scores.GetById(request.Id);

            var scoreDto = _mapper.Map<ScoreDto>(score); 

            return scoreDto;
        }
    }
}
