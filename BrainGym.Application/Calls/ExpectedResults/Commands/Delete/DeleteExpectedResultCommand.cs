using BrainGym.Application.Common.Constants;
using BrainGym.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.ExpectedResults.Commands.Delete
{
    public class DeleteExpectedResultCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteExpectedResultCommandHandler : IRequestHandler<DeleteExpectedResultCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteExpectedResultCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<bool> Handle(DeleteExpectedResultCommand request, CancellationToken cancellationToken)
        {
            var expectedResult = await _uow.ExpectedResults.GetById(request.Id);

            _uow.ExpectedResults.Remove(expectedResult);

            return await _uow.Complete();
        }
    }
}
