using AutoMapper;
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
    public class GetExpectedResultQuery : IRequest<ExpectedResultDto>
    {
        public GetExpectedResultQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }

    public class GetExpectedResultQueryHandler : IRequestHandler<GetExpectedResultQuery, ExpectedResultDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetExpectedResultQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        public async Task<ExpectedResultDto> Handle(GetExpectedResultQuery request, CancellationToken cancellationToken)
        {
            var expectedResult =  await _uow.ExpectedResults.GetById(request.Id);

            return _mapper.Map<ExpectedResultDto>(expectedResult);
        }
    }
}
