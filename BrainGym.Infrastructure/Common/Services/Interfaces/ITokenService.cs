using BrainGym.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Infrastructure.Common.Services.Interfaces
{
    internal interface ITokenService
    {
        public Task<string> CreateToken(AppUser user);
    }
}
