using Domain;
using Infra.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configurations
{
    public static partial class ServicesConfiguration
    {
        public static void ConfigureDbContext(
            this IServiceCollection Services, 
            IWebHostEnvironment Enviroment, 
            IConfiguration Configuration)
        {            
            var connectionString = string.Empty;

            if (Enviroment.EnvironmentName == "Development")
                connectionString = Configuration.GetConnectionString("SqlServerDev");
            else
                connectionString = Configuration.GetConnectionString("SqlServerProd");

            Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));


            // Iniciliza classe de configuração da camada Domain
            new AppSettings(connectionString);
        }
    }
}