using AutoMapper;
using BrainGym.Application.Calls.Exercises.Queries.Get;
using BrainGym.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Exercises.Queries.GetAll
{
    public class GetAllExercisesQuery : IRequest<IQueryable<ExerciseDto>>
    {

    }

    public class GetAllExercisesQueryHandler : IRequestHandler<GetAllExercisesQuery, IQueryable<ExerciseDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllExercisesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<IQueryable<ExerciseDto>> Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
        {
            var exercises = _uow.Exercises.ProjectTo<ExerciseDto>(_mapper.ConfigurationProvider);

            return exercises;            
        }
    }
}
