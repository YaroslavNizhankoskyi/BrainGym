using BrainGym.Application.Common.Constants;
using BrainGym.Application.Common.Exceptions;
using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Factors.Queries.Get
{
    public  class GetFactorQuery : IRequest<Factor>
    {
        public GetFactorQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }

    public class GetFactorQueryHandler : IRequestHandler<GetFactorQuery, Factor>
    {
        private readonly IUnitOfWork _uow;

        public GetFactorQueryHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        public async Task<Factor> Handle(GetFactorQuery request, CancellationToken cancellationToken)
        {
            var factor = await _uow.Factors.GetById(request.Id);

            if (factor == null) throw new NotFoundException(FactorsConstants.FactorNotFound);

            return factor;
        }
    }
}
