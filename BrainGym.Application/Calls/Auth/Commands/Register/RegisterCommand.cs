using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<string>
    {
        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        public RegisterCommandHandler()
        {

        }

        public Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
