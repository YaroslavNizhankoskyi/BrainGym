using BrainGym.Application.Common.Constants;
using BrainGym.Application.Common.Interfaces;
using BrainGym.Application.Common.Models;
using BrainGym.Infrastructure.Common.Services.Interfaces;
using BrainGym.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Infrastructure.Common.Services
{
    internal class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthService(ITokenService tokenService, 
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager)
        {
            this._tokenService = tokenService;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }

        public async Task<AuthResult> AddToRoleAsync(string id, string roleName)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return AuthResult.Error(AuthConstants.UserNotFound);
            }
            else
            {
                var res = await _userManager.AddToRoleAsync(user, roleName);

                if (!res.Succeeded)
                {
                    var errors = res.Errors.Select(x => x.Description);

                    var authResult = new AuthResult();

                    return AuthResult.Error(errors);
                }

                return new AuthResult();
            }
        }

        public async Task<AuthResult<string>> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return AuthResult<string>.Error(AuthConstants.UserNotFound);
            }

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, password, false);

            if (!result.Succeeded)
            {
                return AuthResult<string>.Error(AuthConstants.InvalidCredentials);
            }

            var token = await _tokenService.CreateToken(user);

            return new AuthResult<string>(token);
        }

        public async Task<AuthResult<string>> RegisterAsync(string password, string email)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser != null)
            {
                return AuthResult<string>.Error(AuthConstants.UserAlreadyExists);
            }

            var user = new AppUser()
            {
                Email = email,
                UserName = email
            };

            var res = await _userManager.CreateAsync(user, password);

            if (!res.Succeeded)
            {
                var errors = res.Errors.Select(x => x.Description);

                return AuthResult<string>.Error(errors);
            }

            return new AuthResult<string>(user.Id);
        }

        public async Task<AuthResult> RemoveUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return AuthResult.Error(AuthConstants.UserNotFound);
            }
            else
            {
                var res = await _userManager.DeleteAsync(user);

                if (!res.Succeeded)
                {
                    var errors = res.Errors.Select(x => x.Description);

                    return AuthResult.Error(errors);
                }

                return new AuthResult();
            }
        }
    }
}
