using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Exercises.Commands.Delete
{
    public class DeleteExerciseCommandValidation : AbstractValidator<DeleteExerciseCommand>
    {
        public DeleteExerciseCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotEqual(Guid.Empty);
        }
    }
}
