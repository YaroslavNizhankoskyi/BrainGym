using BrainGym.Application.Common.Interfaces;
using BrainGym.Infrastructure.Common.Helpers;
using BrainGym.Infrastructure.Common.Services;
using BrainGym.Infrastructure.Common.Services.Interfaces;
using BrainGym.Infrastructure.Data.Context;
using BrainGym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BrainGym.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                            options => options.UseSqlServer(
                                configuration["ConnectionStrings:AppDbContext"],
                                m => m.MigrationsAssembly("BrainGym.Infrastructure")));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddAuth();

            return services;
        }
    }

}
