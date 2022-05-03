using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.ExpectedResults.Queries.GetAll
{
    public class GetAllExpectedResultsQuery : IRequest<IEnumerable<ExpectedResult>>
    {
    }

    public class GetAllExpectedResultsQueryHandler : IRequestHandler<GetAllExpectedResultsQuery, IEnumerable<ExpectedResult>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllExpectedResultsQueryHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<IEnumerable<ExpectedResult>> Handle(GetAllExpectedResultsQuery request, CancellationToken cancellationToken)
        {
            return _uow.ExpectedResults.GetAll().ToList();
        }
    }
}
