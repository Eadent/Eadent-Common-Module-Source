using System.Text.Json.Serialization;

namespace Eadent.Common.WebApi.DataTransferObjects.Sessions.Users
{
    public class UserSessionSignInRequestDto
    {
        [JsonPropertyName("eMailAddress")] 
        public string EMailAddress { get; set; }

        [JsonPropertyName("plainTextPassword")]
        public string PlainTextPassword { get; set; }
    }
}
