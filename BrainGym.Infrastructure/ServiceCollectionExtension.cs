using BrainGym.Infrastructure.Common.Helpers;
using BrainGym.Infrastructure.Data.Context;
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

            services.AddAuth();

            return services;
        }
    }

}
