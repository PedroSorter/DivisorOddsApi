using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DivisorsOdds.Presentation.Configurations
{
    public static class CompressionConfiguration
    {
        public static void ConfigureCompression(this IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });
        }
    }
}

