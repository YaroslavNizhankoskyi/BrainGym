using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Recommendations.Commands.Put
{
    public class PutRecommendationCommandValidation : AbstractValidator<PutRecommendationCommand>
    {
        public PutRecommendationCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.Text)
                .NotEmpty()
                .MaximumLength(128);
        }
    }
}
