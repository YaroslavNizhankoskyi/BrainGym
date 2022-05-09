using AutoMapper;
using BrainGym.Application.Common.Constants;
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
    public  class GetFactorQuery : IRequest<FactorDto>
    {
        public GetFactorQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }

    public class GetFactorQueryHandler : IRequestHandler<GetFactorQuery, FactorDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetFactorQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        public async Task<FactorDto> Handle(GetFactorQuery request, CancellationToken cancellationToken)
        {
            var factor = await _uow.Factors.GetById(request.Id);

            var factorDto = _mapper.Map<FactorDto>(factor);
            
            return factorDto;
        }
    }
}
