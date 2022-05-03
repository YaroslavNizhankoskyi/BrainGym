using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Factors.Queries.GetAll
{
    public class GetAllFactorsQuery : IRequest<IEnumerable<Factor>>
    {
    }

    public class GetAllFactorsQueryHandler : IRequestHandler<GetAllFactorsQuery, IEnumerable<Factor>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllFactorsQueryHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<IEnumerable<Factor>> Handle(GetAllFactorsQuery request, CancellationToken cancellationToken)
        {
            return _uow.Factors.GetAll().ToList();            
        }
    }
}
