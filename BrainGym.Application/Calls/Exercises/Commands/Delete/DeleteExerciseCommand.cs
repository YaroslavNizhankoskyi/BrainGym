using BrainGym.Application.Common.Exceptions;
using BrainGym.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Exercises.Commands.Delete
{
    public class DeleteExerciseCommand : IRequest<bool>
    {
        public DeleteExerciseCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }

    public class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteExerciseCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<bool> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _uow.Exercises.GetById(request.Id);

            if(exercise == null)
            {
                throw new NotFoundException();
            }

            _uow.Exercises.Remove(exercise);

            return await _uow.Complete();
        }
    }
}
