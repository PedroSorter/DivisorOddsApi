using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DivisorsOdds.Presentation.Configurations
{
    public static class MvcConfiguration
    {
        public static void ConfigureMvc(this IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
    }
}
