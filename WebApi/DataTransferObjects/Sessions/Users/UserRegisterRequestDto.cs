using System.Text.Json.Serialization;

namespace Eadent.Common.WebApi.DataTransferObjects.Sessions.Users
{
    public class RegisterUserRequestDto
    {
        [JsonPropertyName("createdByApplicationId")]
        int CreatedByApplicationId { get; set; }

        [JsonPropertyName("userGuidString")]
        public string UserGuidString { get; set; }

        [JsonPropertyName("roleId")]
        short RoleId { get; set; }

        [JsonPropertyName("displayName")]
        string DisplayName { get; set; }

        [JsonPropertyName("eMailAddress")]
        public string EMailAddress { get; set; }

        [JsonPropertyName("mobilePhoneNumber")]
        public string MobilePhoneNumber { get; set; }

        [JsonPropertyName("plainTextPassword")]
        public string PlainTextPassword { get; set; }
    }
}
