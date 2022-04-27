using BrainGym.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Infrastructure.Common.Services
{
    internal class AuthServices : IAuthService
    {
        public AuthServices()
        {

        }
        public Task<IdentityResult> AddToRoleAsync(string id, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> Register(string password, string email)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> RemoveUserAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
