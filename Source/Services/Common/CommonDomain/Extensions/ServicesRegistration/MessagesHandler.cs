using CommonDomain.CQRS;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CommonDomain.Extensions.ServicesRegistration
{
    public static class MessagesHandler
    {
        /// <summary>
        /// Configure Command and Query message handler using MediatR framework
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMessagesHandler(this IServiceCollection services, Assembly handlersAssembly)
        {
            services.AddTransient(typeof(IMessages), typeof(MediatRMessagesHandler));
            services.AddMediatR(typeof(ICommand).Assembly, handlersAssembly);
            return services;
        }
    }
}
