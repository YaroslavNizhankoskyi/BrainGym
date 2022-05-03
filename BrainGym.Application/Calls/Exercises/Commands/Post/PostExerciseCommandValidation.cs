using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Exercises.Commands.Post
{
    public class PostExerciseCommandValidation : AbstractValidator<PostExerciseCommand>
    {
        public PostExerciseCommandValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(64);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(1024);
        }
    }
}
