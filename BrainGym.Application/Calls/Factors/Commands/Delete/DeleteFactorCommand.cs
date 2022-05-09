using BrainGym.Application.Common.Constants;
using BrainGym.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Factors.Commands.Delete
{
    public class DeleteFactorCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteFactorCommandHandler : IRequestHandler<DeleteFactorCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteFactorCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<bool> Handle(DeleteFactorCommand request, CancellationToken cancellationToken)
        {
            var factor = await _uow.Factors.GetById(request.Id);

            _uow.Factors.Remove(factor);

            return await _uow.Complete();
        }
    }
}
