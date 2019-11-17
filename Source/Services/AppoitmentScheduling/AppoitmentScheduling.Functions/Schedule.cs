using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AppoitmentScheduling.Domain.AppServices;
using CommonDomain.ValueObjects;
using CommonDomain.CQRS;
using NetCoreInfrastructure.HttpHelpers;

namespace AppoitmentScheduling.Functions
{
    public class GetScheduleForStoreDto
    {
        public Guid StoreId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }

    public partial class GetScheduleForStore
    {
        private readonly IMessages _messages;
        private readonly IHttpRequestConverter _httpRequestConverter;
        private readonly ILogger _log;

        public GetScheduleForStore(IMessages messages, IHttpRequestConverter httpRequestConverter, ILoggerProvider log)
        {
            _messages = messages;
            _httpRequestConverter = httpRequestConverter;
            _log = log.CreateLogger(nameof(GetScheduleForStore));
        }

        [FunctionName("GetScheduleForStore")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            try
            {
                var request = await _httpRequestConverter.ConvertBody<GetScheduleForStoreDto>(req);

                var result = await _messages.Send(new GetStoreScheduleQuery(request.StoreId,
                    new DateTimeRange(request.From, request.To)));

                return new OkObjectResult(result);
            }
            catch(Exception e)
            {
                _log.LogError(e.ToString(), null);
                return new BadRequestResult();
            }
        }
    }
}
