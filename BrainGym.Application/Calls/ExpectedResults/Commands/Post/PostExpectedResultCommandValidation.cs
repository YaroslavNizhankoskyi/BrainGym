using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.ExpectedResults.Commands.Post
{
    public class PostExpectedResultCommandValidation : AbstractValidator<PostExpectedResultCommand>
    {
        public PostExpectedResultCommandValidation()
        {
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
