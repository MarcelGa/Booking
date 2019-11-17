using AppoitmentScheduling.Domain.AppServices;
using CommonDomain.CQRS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using NetCoreInfrastructure.HttpHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppoitmentScheduling.Functions
{
    public class CreateAppoitment
    {
        private readonly IMessages _messages;
        private readonly IHttpRequestConverter _httpRequestConverter;
        private readonly ILogger _log;

        public CreateAppoitment(IMessages messages, IHttpRequestConverter httpRequestConverter, ILoggerProvider log)
        {
            _messages = messages;
            _httpRequestConverter = httpRequestConverter;
            _log = log.CreateLogger(nameof(CreateAppoitment));
        }



        [FunctionName(nameof(CreateAppoitment))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
        {
            var createCommand = new CreateProcedureOrderCommand(Guid.NewGuid(), 
                Guid.NewGuid(), 
                Guid.NewGuid(),
                Guid.NewGuid(), 
                DateTime.Now);

            var response = await _messages.Send(createCommand);

            if (response.IsSuccessful)
                _log.LogInformation("appoitment created");

            return new OkObjectResult(response);
        }
    }
}
