using Eadent.Common.WebApi.DataTransferObjects.Common;
using System.Text.Json.Serialization;
namespace Eadent.Common.WebApi.DataTransferObjects.Sessions.Users
{
    public class UserRegisterResponseDto : BaseResponseDto
    {
        [JsonPropertyName("registerUserStatusId")]
        public short RegisterUserStatusId { get; set; }

        [JsonPropertyName("userId")]
        public long UserId { get; set; }

        [JsonPropertyName("userGuidString")]
        public string UserGuidString { get; set; }
    }
}
