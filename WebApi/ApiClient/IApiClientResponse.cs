namespace Eadent.Common.WebApi.ApiClient
{
    public interface IApiClientResponse<out TResponseDto>
    {
        int HttpStatusCode { get; }

        ApiHeaders HttpResponseHeaders { get; }

        string ResponseText { get; }

        TResponseDto ResponseDto { get; }
    }
}
