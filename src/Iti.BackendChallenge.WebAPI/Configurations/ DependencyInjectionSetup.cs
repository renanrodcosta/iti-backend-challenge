using Iti.BackendChallenge.WebAPI.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Iti.BackendChallenge.WebAPI.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            services.AddScoped<ValidateStrongPassword>();
        }
    }
}