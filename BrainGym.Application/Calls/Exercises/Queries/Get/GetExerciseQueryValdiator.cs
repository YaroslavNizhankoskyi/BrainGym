using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Exercises.Queries.Get
{
    public class GetExerciseQueryValdiator : AbstractValidator<GetExerciseQuery>
    {
        public GetExerciseQueryValdiator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotEqual(Guid.Empty);
        }
    }
}
