using CommonDomain.CQRS;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CommonDomain.Extensions.ServicesRegistration
{
    public static class CQHandler
    {
        /// <summary>
        /// Configure Command and Query message handler using MediatR framework
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCQMessagesHandler(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
