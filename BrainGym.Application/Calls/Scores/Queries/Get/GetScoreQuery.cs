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
    public class GetScoreQuery : IRequest<Score>
    {
        public GetScoreQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }

    }

    public class GetScoreQueryHandler : IRequestHandler<GetScoreQuery, Score>
    {
        private readonly IUnitOfWork _uow;

        public GetScoreQueryHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public Task<Score> Handle(GetScoreQuery request, CancellationToken cancellationToken)
        {
            var score = _uow.Scores.GetById(request.Id);

            return score;
        }
    }
}
