using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Eadent.Common.WebApi.ApiClient
{
    public abstract class ApiClient : IApiClient
    {
        private ILogger Logger { get; }

        private string RestApiBaseUrl { get; }

        protected ApiClient(ILogger logger, string restApiBaseUrl)
        {
            Logger = logger;

            RestApiBaseUrl = restApiBaseUrl;
        }

        public void Dispose()
        {
        }

        protected abstract HttpContent CreateContent<TRequestDto>(TRequestDto requestDto);

        private void AddHeaders(HttpRequestMessage httpRequest, ApiHeaders optionalHeaders)
        {
            if (optionalHeaders != null)
            {
                foreach (var header in optionalHeaders)
                {
                    try
                    {
                        httpRequest.Headers.Add(header.Key, header.Value);
                    }
                    catch (Exception exception)
                    {
                        Logger.LogError(exception, "An Exception occurred.");

                        httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }
            }
        }

        public string UrlCombine(string left, string right)
        {
            string url = null;

            if (string.IsNullOrWhiteSpace(right))
            {
                url = left;
            }
            else if (string.IsNullOrWhiteSpace(left))
            {
                url = right;
            }
            else
            {
                url = left.TrimEnd('/') + "/" + right.TrimStart('/');
            }

            return url;
        }

        public async Task<IApiClientResponse<TResponseDto>> PostAsync<TRequestDto, TResponseDto>(string relativeUrl, TRequestDto requestDto, ApiHeaders optionalHeaders)
        {
            var response = new ApiClientResponse<TResponseDto>()
            {
            };

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var httpContent = CreateContent(requestDto))
                    {
                        using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, UrlCombine(RestApiBaseUrl, relativeUrl)))
                        {
                            httpRequest.Content = httpContent;

                            AddHeaders(httpRequest, optionalHeaders);

                            using (var httpResponse = await httpClient.SendAsync(httpRequest))
                            {
                                response.HttpStatusCode = (int)httpResponse.StatusCode;
                                response.HttpResponseHeaders = new ApiHeaders(httpResponse.Headers);

                                response.ResponseText = await httpResponse.Content.ReadAsStringAsync();

                                if (typeof(TResponseDto) != typeof(string))
                                {
                                    response.ResponseDto = JsonSerializer.Deserialize<TResponseDto>(response.ResponseText);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "An Exception occurred.");

                response.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return response;
        }

        public async Task<IApiClientResponse<TResponseDto>> GetAsync<TResponseDto>(string relativeUrl, ApiHeaders optionalHeaders)
        {
            var response = new ApiClientResponse<TResponseDto>()
            {
            };

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var httpRequest = new HttpRequestMessage(HttpMethod.Get, UrlCombine(RestApiBaseUrl, relativeUrl)))
                    {
                        AddHeaders(httpRequest, optionalHeaders);

                        using (var httpResponse = await httpClient.SendAsync(httpRequest))
                        {
                            response.HttpStatusCode = (int)httpResponse.StatusCode;
                            response.HttpResponseHeaders = new ApiHeaders(httpResponse.Headers);

                            response.ResponseText = await httpResponse.Content.ReadAsStringAsync();

                            if (typeof(TResponseDto) != typeof(string))
                            {
                                response.ResponseDto = JsonSerializer.Deserialize<TResponseDto>(response.ResponseText);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "An Exception occurred.");

                response.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return response;
        }

        public async Task<IApiClientResponse<TResponseDto>> PutAsync<TRequestDto, TResponseDto>(string relativeUrl, TRequestDto requestDto, ApiHeaders optionalHeaders)
        {
            var response = new ApiClientResponse<TResponseDto>()
            {
            };

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var httpContent = CreateContent(requestDto))
                    {
                        using (var httpRequest = new HttpRequestMessage(HttpMethod.Put, UrlCombine(RestApiBaseUrl, relativeUrl)))
                        {
                            httpRequest.Content = httpContent;

                            AddHeaders(httpRequest, optionalHeaders);

                            using (var httpResponse = await httpClient.SendAsync(httpRequest))
                            {
                                response.HttpStatusCode = (int)httpResponse.StatusCode;
                                response.HttpResponseHeaders = new ApiHeaders(httpResponse.Headers);

                                response.ResponseText = await httpResponse.Content.ReadAsStringAsync();

                                if (typeof(TResponseDto) != typeof(string))
                                {
                                    response.ResponseDto = JsonSerializer.Deserialize<TResponseDto>(response.ResponseText);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "An Exception occurred.");

                response.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return response;
        }

        public async Task<IApiClientResponse<TResponseDto>> PatchAsync<TRequestDto, TResponseDto>(string relativeUrl, TRequestDto requestDto, ApiHeaders optionalHeaders)
        {
            var response = new ApiClientResponse<TResponseDto>()
            {
            };

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var httpContent = CreateContent(requestDto))
                    {
                        using (var httpRequest = new HttpRequestMessage(HttpMethod.Patch, UrlCombine(RestApiBaseUrl, relativeUrl)))
                        {
                            httpRequest.Content = httpContent;

                            AddHeaders(httpRequest, optionalHeaders);

                            using (var httpResponse = await httpClient.SendAsync(httpRequest))
                            {
                                response.HttpStatusCode = (int)httpResponse.StatusCode;
                                response.HttpResponseHeaders = new ApiHeaders(httpResponse.Headers);

                                response.ResponseText = await httpResponse.Content.ReadAsStringAsync();

                                if (typeof(TResponseDto) != typeof(string))
                                {
                                    response.ResponseDto = JsonSerializer.Deserialize<TResponseDto>(response.ResponseText);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "An Exception occurred.");

                response.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return response;
        }

        public async Task<IApiClientResponse<TResponseDto>> DeleteAsync<TResponseDto>(string relativeUrl, ApiHeaders optionalHeaders)
        {
            var response = new ApiClientResponse<TResponseDto>()
            {
            };

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var httpRequest = new HttpRequestMessage(HttpMethod.Delete, UrlCombine(RestApiBaseUrl, relativeUrl)))
                    {
                        AddHeaders(httpRequest, optionalHeaders);

                        using (var httpResponse = await httpClient.SendAsync(httpRequest))
                        {
                            response.HttpStatusCode = (int)httpResponse.StatusCode;
                            response.HttpResponseHeaders = new ApiHeaders(httpResponse.Headers);

                            response.ResponseText = await httpResponse.Content.ReadAsStringAsync();

                            if (typeof(TResponseDto) != typeof(string))
                            {
                                response.ResponseDto = JsonSerializer.Deserialize<TResponseDto>(response.ResponseText);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "An Exception occurred.");

                response.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}
