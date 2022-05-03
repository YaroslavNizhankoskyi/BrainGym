using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Recommendations.Commands.Post
{
    public class PostRecommedationCommandValidation : AbstractValidator<PostRecommedationCommand>
    {
        public PostRecommedationCommandValidation()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .MaximumLength(128);                    
        }
    }
}
