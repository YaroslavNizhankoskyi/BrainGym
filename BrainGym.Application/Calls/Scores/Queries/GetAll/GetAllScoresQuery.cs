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
    public class GetAllScoresQuery : IRequest<IEnumerable<Score>>
    {

    }

    public class GetAllScoresQueryHandler : IRequestHandler<GetAllScoresQuery, IEnumerable<Score>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllScoresQueryHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<IEnumerable<Score>> Handle(GetAllScoresQuery request, CancellationToken cancellationToken)
        {
            return _uow.Scores.GetAll().ToList();
        }
    }
}
