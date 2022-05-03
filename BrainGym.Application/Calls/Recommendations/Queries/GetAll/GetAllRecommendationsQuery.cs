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
    public class GetAllRecommendationsQuery : IRequest<IEnumerable<Recommendation>>
    {
    }

    public class GetAllRecommendationsQueryHandler : IRequestHandler<GetAllRecommendationsQuery, IEnumerable<Recommendation>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllRecommendationsQueryHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<IEnumerable<Recommendation>> Handle(GetAllRecommendationsQuery request, CancellationToken cancellationToken)
        {
            return _uow.Recommendations.GetAll().ToList();
        }
    }
}
