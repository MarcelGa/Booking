using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace NetCoreInfrastructure.HttpHelpers
{
    internal class HttpRequestConverter : IHttpRequestConverter
    {
        public async Task<TBody> ConvertBody<TBody>(HttpRequest httpRequest)
        {
            using (var reader = new StreamReader(httpRequest.Body))
            {
                var content = await reader.ReadToEndAsync();
                var body = JsonConvert.DeserializeObject<TBody>(content);
                return body;
            }
        }
    }
}
