using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api.Configurations
{
    public static partial class ServicesConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Auth.NET API",
                    Description = "API for Authentication with JWT",
                    Contact = new OpenApiContact
                    {
                        Name = "Auth.NET",
                        Email = string.Empty
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"<p>Cabeçalho de autorização JWT usando o esquema Bearer.</p>                                
                                <p>Digite 'Bearer' [espaço] em seguida, seu token na entrada de texto abaixo.</p>
                                <p>Exemplo:</p> 
                                <p style='text-indent:4em; color:blue'>Bearer 12345abcdef</p>",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });                    

            });
        }
    }
}