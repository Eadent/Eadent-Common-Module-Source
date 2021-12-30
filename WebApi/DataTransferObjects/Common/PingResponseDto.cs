namespace Eadent.Common.WebApi.DataTransferObjects.Common
{
    public class PingResponseDto : BaseResponseDto
    {
        // Properties for All Requests.
        public string RemoteIpAddress { get; set; }

        public string SoftwareVersion { get; set; }

        // Properties for Signed In Sessions.
        public string LocalIpAddress { get; set; }

        public string LastDatabaseVersion { get; set; }
    }
}
