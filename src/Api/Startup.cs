using System.Linq;
using Api.Configurations;
using Api.Services;
using Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddScoped<TokenService>();
            services.ConfigureJWT();
            services.ConfigureDbContext(Environment, Configuration);
            services.ConfigureRepositories();
            services.ConfigureHandlers();
            services.AddCORS();
            services.ConfigureSwagger();
            services.AddScoped<EmailService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
                InitializeData.InitializeUsers(context);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
