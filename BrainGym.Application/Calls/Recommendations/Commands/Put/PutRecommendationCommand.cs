using BrainGym.Application.Common.Constants;
using BrainGym.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Recommendations.Commands.Put
{
    public class PutRecommendationCommand : IRequest<bool> 
    {
        public Guid Id { get; set; }

        public string Text { get; set; }
    }

    public class PutRecommendationCommandHandler : IRequestHandler<PutRecommendationCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public PutRecommendationCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<bool> Handle(PutRecommendationCommand request, CancellationToken cancellationToken)
        {
            var recommendation = await _uow.Recommendations.GetById(request.Id);

            recommendation.Text = request.Text;

            return await _uow.Complete();
        }
    }
}
