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
        public static void ConfigureDbContext(this IServiceCollection Services, 
            IWebHostEnvironment Enviroment, IConfiguration Configuration)
        {
            var connString = Configuration.GetConnectionString("DefaultConnection");

            Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connString));

            AppSettings.SetConnectionString(connString);
        }
    }
}