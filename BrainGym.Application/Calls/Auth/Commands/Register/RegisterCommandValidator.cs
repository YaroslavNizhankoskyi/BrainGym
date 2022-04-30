using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .MaximumLength(32);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(64);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(64);

            RuleFor(x => x.Role)
                .NotEmpty()
                .MaximumLength(64);


        }
    }
}
