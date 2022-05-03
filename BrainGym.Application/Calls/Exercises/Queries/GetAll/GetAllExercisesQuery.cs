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
    public class GetAllExercisesQuery : IRequest<IEnumerable<ExerciseDto>>
    {

    }

    public class GetAllExercisesQueryHandler : IRequestHandler<GetAllExercisesQuery, IEnumerable<ExerciseDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllExercisesQueryHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<IEnumerable<ExerciseDto>> Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
        {
            var exercises = _uow.Exercises
                .GetAll()
                .ToList()
                .Select(x => new ExerciseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    GameData = x.GameData,
                    ExerciseMode = x.ExerciseMode,
                    ExerciseType = x.ExerciseType
                });

            return exercises;            
        }
    }
}
