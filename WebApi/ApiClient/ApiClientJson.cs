using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Eadent.Common.WebApi.ApiClient
{
    public class ApiClientJson : Common.WebApi.ApiClient.ApiClient
    {
        public ApiClientJson(ILogger logger, string restApiBaseUrl) : base(logger, restApiBaseUrl)
        {
        }
        
        protected override HttpContent CreateContent<TRequestDto>(TRequestDto requestDto)
        {
            var jsonString = JsonSerializer.Serialize(requestDto);

            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            return httpContent;
        }
    }
}
