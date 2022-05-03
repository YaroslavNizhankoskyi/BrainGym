using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Factors.Commands.Put
{
    public class PutFactorCommandValdation : AbstractValidator<PutFactorCommand>
    {
        public PutFactorCommandValdation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.Coefficient)
                .Must(x => x >= 0 && x < 1);

            RuleFor(x => x.ExerciseId)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.RecommendationId)
                .NotEmpty()
                .NotEqual(Guid.Empty);
        }

    }
}
