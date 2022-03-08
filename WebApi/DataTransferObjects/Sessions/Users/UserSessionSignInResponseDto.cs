using System;
using System.Text.Json.Serialization;
using Eadent.Common.WebApi.DataTransferObjects.Common;

namespace Eadent.Common.WebApi.DataTransferObjects.Sessions.Users
{
    public class UserSessionSignInResponseDto : BaseResponseDto
    {
        [JsonPropertyName("sessionToken")]
        public string SessionToken { get; set; }

        [JsonPropertyName("signInUrl")]
        public string SignInUrl { get; set; }

        [JsonPropertyName("previousSignInDateTimeUtc")]
        public DateTime? PreviousSignInDateTimeUtc { get; set; }

        [JsonPropertyName("signInLockOutDateTimeUtc")]
        public DateTime? SignInLockOutDateTimeUtc { get; set; }

        [JsonPropertyName("signInLockOutDurationSeconds")]
        public long? SignInLockOutDurationSeconds { get; set; }
    }
}
