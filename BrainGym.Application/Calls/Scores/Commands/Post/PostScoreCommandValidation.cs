using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Scores.Commands.Post
{
    public class PostScoreCommandValidation : AbstractValidator<PostScoreCommand>
    {
        public PostScoreCommandValidation()
        {
            RuleFor(x => x.HealthRate)
                .LessThan(10)
                .GreaterThan(0);

            RuleFor(x => x.MentalRate)
                .LessThan(10)
                .GreaterThan(0);

            RuleFor(x => x.SleepRate)
                .LessThan(10)
                .GreaterThan(0);

            RuleFor(x => x.ExerciseId)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.GameScore)
                .Must(x => x >= 0);
        }
    }
}
