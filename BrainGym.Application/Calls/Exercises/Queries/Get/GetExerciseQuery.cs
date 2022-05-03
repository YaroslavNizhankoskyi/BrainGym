using BrainGym.Application.Common.Exceptions;
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

        public GetExerciseQueryHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<ExerciseDto> Handle(GetExerciseQuery request, CancellationToken cancellationToken)
        {
            var exercise = await _uow.Exercises.GetById(request.Id);

            if (exercise == null) throw new NotFoundException();

            return new ExerciseDto
            {
                Name = exercise.Name,
                Description = exercise.Description,
                GameData = exercise.GameData,
                ExerciseMode = exercise.ExerciseMode,
                ExerciseType = exercise.ExerciseType
            };
        }
    }
}
