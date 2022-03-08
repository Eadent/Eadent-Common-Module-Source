using System.Text.Json.Serialization;

namespace Eadent.Common.WebApi.DataTransferObjects.Common
{
    public class PingResponseDto : BaseResponseDto
    {
        // Properties for All Requests.
        [JsonPropertyName("remoteIpAddress")]
        public string RemoteIpAddress { get; set; }

        [JsonPropertyName("softwareVersion")]
        public string SoftwareVersion { get; set; }

        // Properties for Signed In Sessions.
        [JsonPropertyName("localIpAddress")]
        public string LocalIpAddress { get; set; }

        [JsonPropertyName("lastDatabaseVersion")]
        public string LastDatabaseVersion { get; set; }
    }
}
