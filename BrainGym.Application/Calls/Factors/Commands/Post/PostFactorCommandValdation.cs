using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Factors.Commands.Post
{
    public class PostFactorCommandValdation : AbstractValidator<PostFactorCommand>
    {
        public PostFactorCommandValdation()
        {
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
