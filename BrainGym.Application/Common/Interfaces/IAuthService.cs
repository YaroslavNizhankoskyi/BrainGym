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
        public Task<string> Register(string password, string email);
        Task<IdentityResult> RemoveUserAsync(string id);
        Task<IdentityResult> AddToRoleAsync(string id, string roleName);
        Task<string> LoginAsync(string email, string password);
    }
}
