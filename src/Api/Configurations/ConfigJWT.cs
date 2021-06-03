using System.Text;
using Api.Services;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Api.Configurations
{
    public static partial class ServicesConfiguration
    {
        public static void ConfigureJWT(this IServiceCollection services)
        {
            services.AddScoped<TokenService>();

            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // ValidIssuers = AppSettings.Dominios,
                    // ValidAudiences = AppSettings.Emissores,
                };
            });

        }
    }
}