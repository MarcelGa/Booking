using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppoitmentScheduling.Functions
{
    public class GetSchedule
    {

        [FunctionName(nameof(GetSchedule))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Schedule/{from:datetime}/{to:datetime}/{id:int}")] HttpRequest req,
            DateTime from, 
            DateTime to,
            int id)
        {
            await Task.Delay(500);

            return new OkObjectResult($"Get schedule from {from} to {to} for store with Id {id}");
        }
    }
}
