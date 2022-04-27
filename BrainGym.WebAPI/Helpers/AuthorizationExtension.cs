using BrainGym.Application.Common.Constants;

namespace BrainGym.WebAPI.Helpers
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection AddAppAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy(RolePolicy.AdministratorPolicy,
                    policy => policy.RequireRole(RoleConstants.Administrator));
                auth.AddPolicy(RolePolicy.UserPolicy,
                    policy => policy.RequireRole(RoleConstants.User));
                auth.AddPolicy(RolePolicy.AdminOrUser,
                    policy => policy.RequireRole(RoleConstants.Administrator, RoleConstants.User));
            });

            return services;
        }
    }

}
