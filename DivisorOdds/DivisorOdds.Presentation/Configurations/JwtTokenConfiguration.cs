using DivisorOdds.CrossCutting.DefaultObjects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace DivisorsOdds.Presentation.Configurations
{
    public static class JwtTokenConfiguration
    {
        public static void ConfigureJwtTokenService(this IServiceCollection services, IConfiguration config)
        {
            IConfigurationSection tokenConfigurationsSection = config.GetSection("TokenConfigurations");
            services.Configure<Token>(tokenConfigurationsSection);

            Token tonkenConfigurations = tokenConfigurationsSection.Get<Token>();
            byte[] key = Encoding.ASCII.GetBytes(tonkenConfigurations.Secret);

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(0)
                };
            });
        }
    }
}
