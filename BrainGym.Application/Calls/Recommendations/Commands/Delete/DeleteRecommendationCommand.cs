using BrainGym.Application.Common.Constants;
using BrainGym.Application.Common.Exceptions;
using BrainGym.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Recommendations.Commands.Delete
{
    public class DeleteRecommendationCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteRecommendationCommandHandler : IRequestHandler<DeleteRecommendationCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteRecommendationCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<bool> Handle(DeleteRecommendationCommand request, CancellationToken cancellationToken)
        {
            var recommendation = await _uow.Recommendations.GetById(request.Id);

            if (recommendation == null) throw new NotFoundException(RecommendationConstants.RecommednationNotFound);

            _uow.Recommendations.Remove(recommendation);

            return await _uow.Complete();
        }
    }
}
