using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Recommendations.Commands.Post
{
    public class PostRecommedationCommand : IRequest<Guid>
    {
        public string Text { get; set; }
    }

    public class PostRecommedationCommandHandler : IRequestHandler<PostRecommedationCommand, Guid>
    {
        private readonly IUnitOfWork _uow;

        public PostRecommedationCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        public async Task<Guid> Handle(PostRecommedationCommand request, CancellationToken cancellationToken)
        {
            var recommendation = new Recommendation
            {
                Text = request.Text
            };

            _uow.Recommendations.Add(recommendation);

            await _uow.Complete();

            return recommendation.Id;
        }
    }
}
