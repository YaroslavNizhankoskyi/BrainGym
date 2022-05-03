using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.ExpectedResults.Queries.Get
{
    public class GetExpectedResultQueryValidation : AbstractValidator<GetExpectedResultQuery>
    {
        public GetExpectedResultQueryValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotEqual(Guid.Empty);
        }
    }
}
