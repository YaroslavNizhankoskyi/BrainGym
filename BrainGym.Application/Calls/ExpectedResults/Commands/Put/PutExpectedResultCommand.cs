using BrainGym.Application.Common.Constants;
using BrainGym.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.ExpectedResults.Commands.Put
{
    public class PutExpectedResultCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid RecommendationId { get; set; }

        public Guid ExerciseId { get; set; }

        public double Value { get; set; }
    }

    public class PutExpectedResultCommandHandler : IRequestHandler<PutExpectedResultCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public PutExpectedResultCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        public async Task<bool> Handle(PutExpectedResultCommand request, CancellationToken cancellationToken)
        {
            var expectedResult = await _uow.ExpectedResults.GetById(request.Id);

            var recommendation = await _uow.Recommendations.GetById(request.RecommendationId);

            var exercise = await _uow.Exercises.GetById(request.ExerciseId);

            expectedResult.ExerciseId = request.Id;
            expectedResult.RecommendationId = request.Id;
            expectedResult.Value = request.Value;

            return await _uow.Complete();
        }
    }
}
