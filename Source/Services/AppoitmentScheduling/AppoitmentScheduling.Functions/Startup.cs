using CommonDomain.CQRS;
using CommonDomain.Extensions.ServicesRegistration;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(AppoitmentScheduling.Functions.Startup))]
namespace AppoitmentScheduling.Functions
{    
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            MessagesHandler.AddMessagesHandler(builder.Services, typeof(Domain.AppServices.AddProcedureOrderCommand).Assembly);
        }
    }
}
