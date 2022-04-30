using BrainGym.Application.Common.Interfaces;
using BrainGym.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AuthResult<string>>
    {
        public string Password { get; set; }

        public string Email { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResult<string>>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            this._authService = authService;
        }

        public async Task<AuthResult<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _authService.LoginAsync(request.Email, request.Password);
        }
    }
}
