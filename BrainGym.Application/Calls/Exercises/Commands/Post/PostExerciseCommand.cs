using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Exercises.Commands.Post
{
    public class PostExerciseCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ExerciseMode ExerciseMode { get; set; }

        public ExerciseType ExerciseType { get; set; }

        public string GameData { get; set; }
    }

    public class PostExerciseCommandHandler : IRequestHandler<PostExerciseCommand, Guid>
    {
        private readonly IUnitOfWork _uow;

        public PostExerciseCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<Guid> Handle(PostExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = new Exercise
            {
                Name = request.Name,
                Description = request.Description,
                ExerciseType = request.ExerciseType,
                ExerciseMode = request.ExerciseMode,
                GameData = request.GameData
            };

            _uow.Exercises.Add(exercise);

            await _uow.Complete();

            return exercise.Id;
        }
    }
}
