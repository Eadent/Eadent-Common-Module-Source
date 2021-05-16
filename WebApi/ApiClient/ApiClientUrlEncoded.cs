using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Eadent.Common.WebApi.ApiClient
{
    public class ApiClientUrlEncoded : Common.WebApi.ApiClient.ApiClient
    {
        private ILogger Logger { get; }

        public ApiClientUrlEncoded(ILogger logger, string restApiBaseUrl) : base(logger, restApiBaseUrl)
        {
            Logger = logger;
        }

        protected override HttpContent CreateContent<TRequestDto>(TRequestDto requestDto)
        {
            var enumerable = requestDto as IEnumerable<KeyValuePair<string, string>>;

            if (enumerable == null)
            {
                Logger.LogError($"Incompatible Content.");

                throw new NotSupportedException();
            }

            return new FormUrlEncodedContent(enumerable);
        }
    }
}
