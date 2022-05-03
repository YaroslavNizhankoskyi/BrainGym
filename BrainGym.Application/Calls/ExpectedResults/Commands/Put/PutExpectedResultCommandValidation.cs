using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.ExpectedResults.Commands.Put
{
    public class PutExpectedResultCommandValidation : AbstractValidator<PutExpectedResultCommand>
    {
        public PutExpectedResultCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.ExerciseId)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.RecommendationId)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.Value)
                .Must(x => x >= 0);
        }
    }
}
