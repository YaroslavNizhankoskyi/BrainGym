using BrainGym.Application.Common.Constants;
using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Factors.Commands.Post
{
    public class PostFactorCommand : IRequest<Guid>
    {
        public Guid ExerciseId { get; set; }

        public Guid RecommendationId { get; set; }

        public FactorType FactorType { get; set; }

        public double Coefficient { get; set; }
    }

    public class PostFactorCommandHandler : IRequestHandler<PostFactorCommand, Guid>
    {
        private readonly IUnitOfWork _uow;

        public PostFactorCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        public async Task<Guid> Handle(PostFactorCommand request, CancellationToken cancellationToken)
        {
            var recommendation = await _uow.Recommendations.GetById(request.RecommendationId);

            var exercise = await _uow.Exercises.GetById(request.ExerciseId);

            var factor = new Factor
            {
                ExerciseId = request.ExerciseId,
                RecommendationId = request.RecommendationId,
                Coefficient = request.Coefficient,
                FactorType = request.FactorType
            };

            _uow.Factors.Add(factor);

            await _uow.Complete();
        
            return factor.Id;
        }
    }
}
