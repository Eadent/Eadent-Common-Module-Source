using Microsoft.AspNetCore.Http;

namespace Eadent.Common.WebApi.Helpers
{
    public class HttpHelper
    {
        public static string GetRemoteAddress(HttpRequest request)
        {
            var remoteAddressString = "*** Unknown ***";

            if (request != null)
            {
                var remoteAddress = request.HttpContext.Connection.RemoteIpAddress;

                if (remoteAddress != null)
                {
                    remoteAddressString = remoteAddress.ToString();
                }
            }

            return remoteAddressString;
        }

        public static string GetLocalAddress(HttpRequest request)
        {
            var hostAddressString = "*** Unknown ***";

            if (request != null)
            {
                var hostAddress = request.HttpContext.Connection.LocalIpAddress;

                if (hostAddress != null)
                {
                    hostAddressString = hostAddress.ToString();
                }
            }

            return hostAddressString;
        }
    }
}
