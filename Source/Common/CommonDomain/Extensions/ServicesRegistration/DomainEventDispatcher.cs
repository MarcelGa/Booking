using CommonDomain.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CommonDomain.Extensions.ServicesRegistration
{
    public static class DomainEventDispatcher
    {
        /// <summary>
        /// Configure domain event dispatcher using MediatR framework
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDomainEventDispatcher(this IServiceCollection services)
        {
            services.AddTransient<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
