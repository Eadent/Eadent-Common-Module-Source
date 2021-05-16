using System;
using System.Threading.Tasks;

// TODO: Look into IHttpClientFactory.

namespace Eadent.Common.WebApi.ApiClient
{
    public interface IApiClient : IDisposable
    {
        string UrlCombine(string left, string right);

        Task<IApiClientResponse<TResponseDto>> PostAsync<TRequestDto, TResponseDto>(string relativeUrl, TRequestDto requestDto, ApiHeaders optionalHeaders);

        Task<IApiClientResponse<TResponseDto>> GetAsync<TResponseDto>(string relativeUrl, ApiHeaders optionalHeaders);

        Task<IApiClientResponse<TResponseDto>> PutAsync<TRequestDto, TResponseDto>(string relativeUrl, TRequestDto requestDto, ApiHeaders optionalHeaders);

        Task<IApiClientResponse<TResponseDto>> DeleteAsync<TResponseDto>(string relativeUrl, ApiHeaders optionalHeaders);
    }
}
