using Domain.Contracts.Handlers;
using Domain.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configurations
{
    public static partial class ServicesConfiguration
    {
        public static void ConfigureHandlers(this IServiceCollection services)
        {
            services.AddScoped<IUserHandler, UserHandler>();            
        }
    }
}