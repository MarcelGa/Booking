using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AppoitmentScheduling.Domain.AppServices;
using CommonDomain.ValueObjects;
using CommonDomain.CQRS;

namespace AppoitmentScheduling.Functions
{
    public class GetScheduleForStoreDto
    {
        public /*Guid*/int StoreId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }

    public class GetScheduleForStore
    {
        private readonly IMessages _messages;

        public GetScheduleForStore(IMessages messages)
        {
            _messages = messages;
        }

        [FunctionName("GetScheduleForStore")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                var request = await HttpRequestConverter.Convert<GetScheduleForStoreDto>(req);

                var result = await _messages.Send(new GetStoreScheduleQuery(request.StoreId,
                    new DateTimeRange(request.From, request.To)));

                return new OkObjectResult(result);
            }
            catch(Exception e)
            {
                log.LogError(e.ToString(), null);
                return new BadRequestResult();
            }
        }

        private class HttpRequestConverter
        {
            public static async Task<TBody> Convert<TBody>(HttpRequest httpRequest)
            {
                var content = await new StreamReader(httpRequest.Body).ReadToEndAsync();
                var body = JsonConvert.DeserializeObject<TBody>(content);

                return body;
            }
        }
    }
}
