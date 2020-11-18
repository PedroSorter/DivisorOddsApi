using DivisorOdds.Domain.Handlers;
using DivisorOdds.Domain.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace DivisorOdds.Domain.DependencyInjection
{
    public static class DomainDependencYInjection
    {
        public static IServiceCollection AddDomainDependecies(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<INumberHandler, NumberHandler>();

            return services;
        }
    }
}
