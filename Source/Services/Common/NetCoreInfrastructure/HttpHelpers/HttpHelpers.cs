using Microsoft.Extensions.DependencyInjection;
using System;

namespace NetCoreInfrastructure.HttpHelpers
{
    public static class HttpHelpers
    {
        public static IServiceCollection AddHttpRequestConverter(this IServiceCollection services)
        {
            services.AddTransient(typeof(IHttpRequestConverter), typeof(HttpRequestConverter));
            return services;
        }
    }
}
