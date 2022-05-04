using AutoMapper;
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
    public class GetAllFactorsQuery : IRequest<IQueryable<FactorDto>>
    {
    }

    public class GetAllFactorsQueryHandler : IRequestHandler<GetAllFactorsQuery, IQueryable<FactorDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllFactorsQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<IQueryable<FactorDto>> Handle(GetAllFactorsQuery request, CancellationToken cancellationToken)
        {
            return _uow.Factors.ProjectTo<FactorDto>(_mapper.ConfigurationProvider);            
        }
    }
}
