using BrainGym.Application.Common.Constants;
using BrainGym.Application.Common.Exceptions;
using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MathNet.Numerics.Statistics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.User.Queries.FactorRecommendation
{
    public class GetFactorRecommendationRequest : IRequest<FactorRecommendationResponse>
    {
        public GetFactorRecommendationRequest(Guid exerciseId)
        {
            ExerciseId = exerciseId;
        }
        public Guid ExerciseId { get; set; }
    }

    public class GetFactorRecommendationRequestHandler : IRequestHandler<GetFactorRecommendationRequest, FactorRecommendationResponse>
    {
        private const int MinimalNumberOfScores = 5;
        private readonly IUnitOfWork _uow;
        private readonly ICurrentUserService _currentUser;
        private readonly IFactorService _factorService;

        public GetFactorRecommendationRequestHandler(IUnitOfWork uow, 
            ICurrentUserService currentUser, 
            IFactorService factorService)
        {
            this._uow = uow;
            this._currentUser = currentUser;
            this._factorService = factorService;
        }

        public async Task<FactorRecommendationResponse> Handle(GetFactorRecommendationRequest request, CancellationToken cancellationToken)
        {
            var user = _uow.Users.Get(x => x.UserId == _currentUser.UserId)
                .FirstOrDefault();

            var exercise = await _uow.Exercises.GetById(request.ExerciseId);

            var userScores = _uow.Scores.Get(x => x.ExerciseId == exercise.Id).ToList();

            if (userScores.Count < MinimalNumberOfScores)
            {
                return FactorRecommendationResponse.Error(UsersConstants.NotEnoughScores);
            }

            var factor = _factorService.GetFactorWithCorrelation(userScores);

            var recommendation = await _uow.Recommendations.GetById(factor.RecommendationId);

            return new FactorRecommendationResponse(factor.FactorType, recommendation.Text);
        }
    }    
}
