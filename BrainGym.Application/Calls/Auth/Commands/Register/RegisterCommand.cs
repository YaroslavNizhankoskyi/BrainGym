using BrainGym.Application.Common.Interfaces;
using BrainGym.Application.Common.Models;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<AuthResult<string>>
    {
        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Role { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResult<string>>
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _uow;

        public RegisterCommandHandler(IAuthService authService, IUnitOfWork uow)
        {
            this._authService = authService;
            this._uow = uow;
        }        

        public async Task<AuthResult<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerResult = await _authService.RegisterAsync(request.Password, request.Email);

            if (!registerResult.Secceeded)
            {
                return registerResult;
            }

            var addToRoleResult = await _authService.AddToRoleAsync(registerResult.Result, request.Role);

            if (!addToRoleResult.Secceeded)
            {
                return await DeleteUser(registerResult.Result);
            }

            var user = new User()
            {
                UserId = registerResult.Result,
                FirstName = request.FirstName,
                SecondName = request.SecondName                
            };

            _uow.Users.Add(user);

            if(await _uow.Complete())
            {
                return registerResult;
            }

            return await DeleteUser(registerResult.Result);
        }

        private async Task<AuthResult<string>> DeleteUser(string userId)
        {
            var deleteResult = await _authService.RemoveUserAsync(userId);

            return AuthResult<string>.Error(deleteResult.ErrorList);
        }
    }
}
