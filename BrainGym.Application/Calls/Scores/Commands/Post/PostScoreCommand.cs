using BrainGym.Application.Common.Constants;
using BrainGym.Application.Common.Exceptions;
using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Scores.Commands.Post
{
    public class PostScoreCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public Guid ExerciseId { get; set; }

        public double GameScore { get; set; }

        public int HealthRate { get; set; }

        public int MentalRate { get; set; }

        public int SleepRate { get; set; }
    }

    public class PostScoreCommandHandler : IRequestHandler<PostScoreCommand, Guid>
    {
        private readonly IUnitOfWork _uow;

        public PostScoreCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<Guid> Handle(PostScoreCommand request, CancellationToken cancellationToken)
        {
            var user = await _uow.Scores.GetById(request.UserId);

            var exercise = await _uow.Scores.GetById(request.ExerciseId);

            if(user == null)
            {
                throw new NotFoundException(ScoreConstants.UserNotFound);
            }

            if(exercise == null)
            {
                throw new NotFoundException(ScoreConstants.ExerciseNotFound);
            }

            var score = new Score
            {
                UserId = request.UserId,
                ExerciseId = request.ExerciseId,
                GameScore = request.GameScore,
                HealthRate = request.HealthRate,
                MentalRate = request.MentalRate,
                SleepRate = request.SleepRate
            };

            _uow.Scores.Add(score);

            await _uow.Complete();

            return score.Id;
        }
    }
}
