using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.ExpectedResults.Queries.Get
{
    public class GetExpectedResultQuery : IRequest<ExpectedResult>
    {
        public GetExpectedResultQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }

    public class GetExpectedResultQueryHandler : IRequestHandler<GetExpectedResultQuery, ExpectedResult>
    {
        private readonly IUnitOfWork _uow;

        public GetExpectedResultQueryHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        public async Task<ExpectedResult> Handle(GetExpectedResultQuery request, CancellationToken cancellationToken)
        {
            return await _uow.ExpectedResults.GetById(request.Id);
        }
    }
}
