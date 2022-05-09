using BrainGym.Application.Common.Constants;
using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Exercises.Commands.Put
{
    public class PutExerciseCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public ExerciseMode ExerciseMode { get; set; }

        public ExerciseType ExerciseType { get; set; }

        public string GameData { get; set; }
    }

    public class PutExerciseCommandHandler : IRequestHandler<PutExerciseCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public PutExerciseCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<bool> Handle(PutExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _uow.Exercises.GetById(request.Id);

            exercise.Name = request.Name;
            exercise.Description = request.Description;
            exercise.ExerciseMode = request.ExerciseMode;
            exercise.ExerciseType = request.ExerciseType;
            exercise.GameData = request.GameData;

            return await _uow.Complete();
        }
    }
}
