using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NetCoreInfrastructure.HttpHelpers
{
    public interface IHttpRequestConverter
    {
        Task<TBody> ConvertBody<TBody>(HttpRequest httpRequest);
    }
}
