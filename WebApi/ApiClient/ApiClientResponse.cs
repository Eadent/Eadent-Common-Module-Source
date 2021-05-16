namespace Eadent.Common.WebApi.ApiClient
{
    public class ApiClientResponse<TResponseDto> : IApiClientResponse<TResponseDto>
    {
        public int HttpStatusCode { get; set; }

        public ApiHeaders HttpResponseHeaders { get; set; }

        public string ResponseText { get; set; }

        public TResponseDto ResponseDto { get; set; }
    }
}
