using BrainGym.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Common.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthResult<string>> RegisterAsync(string password, string email);
        Task<AuthResult> RemoveUserAsync(string id);
        Task<AuthResult> AddToRoleAsync(string id, string roleName);
        Task<AuthResult<string>> LoginAsync(string email, string password);
    }
}
