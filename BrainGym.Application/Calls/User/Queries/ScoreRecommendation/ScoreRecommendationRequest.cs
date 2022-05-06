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

namespace BrainGym.Application.Calls.User.Queries.ScoreRecommendation
{
    public class ScoreRecommendationRequest : IRequest<string>
    {
        public ScoreRecommendationRequest(Guid scoreId)
        {
            ScoreId = scoreId;
        }
        public Guid ScoreId { get; set; }
    }

    public class ScoreRecommendationRequestHandler : IRequestHandler<ScoreRecommendationRequest, string>
    {
        private readonly IUnitOfWork _uow;

        public ScoreRecommendationRequestHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        public async Task<string> Handle(ScoreRecommendationRequest request, CancellationToken cancellationToken)
        {
            var score = await _uow.Scores.GetById(request.ScoreId);

            if (score == null) throw new NotFoundException(ScoreConstants.ScoreNotFound);

            var expectedResults = _uow.ExpectedResults
                .Get(x => x.ExerciseId == score.ExerciseId)
                .ToList();

            if (!expectedResults.Any()) throw new ApplicationException(UsersConstants.NoExpectedResults);

            var closestExpectedResult = CalculateClosestExpectedResult(score.GameScore, expectedResults);

            var recommendation = await _uow.Recommendations.GetById(closestExpectedResult.RecommendationId);

            if (recommendation == null) throw new NotFoundException(RecommendationConstants.RecommednationNotFound);

            return recommendation.Text;

        }

        private ExpectedResult CalculateClosestExpectedResult(double score, List<ExpectedResult> expectedResults)
        {
            var closest = expectedResults.Last();

            var minAbs = Math.Abs(expectedResults.Last().Value - score);

            foreach(var expectedResult in expectedResults)
            {
                var abs = Math.Abs(expectedResult.Value - score);
                
                if (minAbs > abs)
                {
                    closest = expectedResult;
                    minAbs = abs; 
                }
            }

            return closest;
        }
    }
}
