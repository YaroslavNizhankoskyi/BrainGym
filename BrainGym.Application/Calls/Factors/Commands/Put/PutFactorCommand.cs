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

namespace BrainGym.Application.Calls.Factors.Commands.Put
{
    public class PutFactorCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid ExerciseId { get; set; }

        public Guid RecommendationId { get; set; }

        public FactorType FactorType { get; set; }

        public double Coefficient { get; set; }
    }

    public class PutFactorCommandHandler : IRequestHandler<PutFactorCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public PutFactorCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<bool> Handle(PutFactorCommand request, CancellationToken cancellationToken)
        {
            var factor = await _uow.Factors.GetById(request.Id);

            if (factor == null) throw new NotFoundException(FactorsConstants.FactorNotFound);

            var recommendation = await _uow.Recommendations.GetById(request.RecommendationId);

            if (recommendation == null) throw new NotFoundException(FactorsConstants.RecommendationNotFound);

            var exercise = await _uow.Exercises.GetById(request.ExerciseId);

            if (exercise == null) throw new NotFoundException(FactorsConstants.ExerciseNotFound);

            factor.RecommendationId = request.RecommendationId;
            factor.ExerciseId = request.ExerciseId;
            factor.Coefficient = request.Coefficient;
            factor.FactorType = request.FactorType;

            return await _uow.Complete();        
        }
    }
}
