using AutoMapper;
using BrainGym.Application.Common.Constants;
using BrainGym.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Exercises.Queries.Get
{
    public class GetExerciseQuery : IRequest<ExerciseDto>
    {
        public GetExerciseQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }

    public class GetExerciseQueryHandler : IRequestHandler<GetExerciseQuery, ExerciseDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetExerciseQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<ExerciseDto> Handle(GetExerciseQuery request, CancellationToken cancellationToken)
        {
            var exercise = await _uow.Exercises.GetById(request.Id);

            return _mapper.Map<ExerciseDto>(exercise);
        }
    }
}
