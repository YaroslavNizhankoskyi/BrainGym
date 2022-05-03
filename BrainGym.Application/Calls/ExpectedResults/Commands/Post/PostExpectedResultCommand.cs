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

namespace BrainGym.Application.Calls.ExpectedResults.Commands.Post
{
    public class PostExpectedResultCommand : IRequest<Guid>
    {
        public Guid RecommendationId { get; set; }

        public Guid ExerciseId { get; set; }

        public double Value { get; set; }
    }

    public class PostExpectedResultCommandHandler : IRequestHandler<PostExpectedResultCommand, Guid>
    {
        private readonly IUnitOfWork _uow;

        public PostExpectedResultCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<Guid> Handle(PostExpectedResultCommand request, CancellationToken cancellationToken)
        {
            var recommendation = await _uow.Recommendations.GetById(request.RecommendationId);

            var exercise = await _uow.Exercises.GetById(request.ExerciseId);

            if (recommendation == null) throw new NotFoundException(ExpectedResultsConstants.RecommendationNotFound);

            if (exercise== null) throw new NotFoundException(ExpectedResultsConstants.ExerciseNotFound);

            var expectedResult = new ExpectedResult
            {
                RecommendationId = request.RecommendationId,
                ExerciseId = request.ExerciseId,
                Value = request.Value
            };

            _uow.ExpectedResults.Add(expectedResult);

            await _uow.Complete();

            return expectedResult.Id;
        }
    }
}
