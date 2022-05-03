using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Scores.Queries.Get
{
    public class GetQueryScoreValidation : AbstractValidator<GetScoreQuery>
    {
        public GetQueryScoreValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotEqual(Guid.Empty);
        }
    }
}
