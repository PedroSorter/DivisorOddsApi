using Microsoft.Extensions.DependencyInjection;

namespace DivisorsOdds.Presentation.Configurations
{
    public static class CorsConfiguration
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .SetIsOriginAllowed(isOriginAllowed: _ => true) 
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                );
            });
        }
    }
}
