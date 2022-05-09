using BrainGym.Application.Common.Constants;
using BrainGym.Application.Common.Exceptions;
using BrainGym.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Exercises.Commands.FileUpload
{
    public class ExerciseFileUploadCommand : IRequest<bool>
    {
        public ExerciseFileUploadCommand(Guid id, byte[] fileData)
        {
            Id = id;
            FileData = fileData;
        }
        public byte[] FileData { get; set; }

        public Guid Id { get; set; }
    }

    public class ExerciseFileUploadCommandHandler : IRequestHandler<ExerciseFileUploadCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public ExerciseFileUploadCommandHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<bool> Handle(ExerciseFileUploadCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _uow.Exercises.GetById(request.Id);

            if (exercise == null) throw new NotFoundException(ExercisesConstants.ExerciseNotFound);

            exercise.GameData = Encoding.UTF8.GetString(request.FileData);

            return await _uow.Complete();
        }
    }
}
