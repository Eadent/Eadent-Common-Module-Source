using System;
using Eadent.Common.WebApi.DataTransferObjects.Common;

namespace Eadent.Common.WebApi.DataTransferObjects.Sessions.Users
{
    public class UserSessionSignInResponseDto : BaseResponseDto
    {
        public string sessionToken { get; set; }

        public string signInUrl { get; set; }

        public DateTime? previousSignInDateTimeUtc { get; set; }

        public DateTime? signInLockOutDateTimeUtc { get; set; }

        public long? signInLockOutDurationSeconds { get; set; }
    }
}
