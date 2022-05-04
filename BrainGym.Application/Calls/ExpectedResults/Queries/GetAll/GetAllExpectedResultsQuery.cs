using AutoMapper;
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
    public class GetAllExpectedResultsQuery : IRequest<IQueryable<ExpectedResultDto>>
    {
    }

    public class GetAllExpectedResultsQueryHandler : IRequestHandler<GetAllExpectedResultsQuery, IQueryable<ExpectedResultDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllExpectedResultsQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<IQueryable<ExpectedResultDto>> Handle(GetAllExpectedResultsQuery request, CancellationToken cancellationToken)
        {
            return _uow.ExpectedResults.ProjectTo<ExpectedResultDto>(_mapper.ConfigurationProvider);
        }
    }
}
