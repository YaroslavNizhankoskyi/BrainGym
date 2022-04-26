using BrainGym.Domain;
using BrainGym.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using BrainGym.Infrastructure.Data.Models;

namespace BrainGym.Infrastructure.Common.Helpers
{
    public static class AddAuthExtension
    {
        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }
    }

}
