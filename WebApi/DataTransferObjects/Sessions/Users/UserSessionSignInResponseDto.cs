using System;
using Eadent.Common.WebApi.DataTransferObjects.Common;

namespace Eadent.Common.WebApi.DataTransferObjects.Sessions.Users
{
    public class UserSessionSignInResponseDto : BaseResponseDto
    {
        public string SessionToken { get; set; }

        public DateTime? PreviousSignInDateTimeUtc { get; set; }

        public DateTime? SignInLockOutDateTimeUtc { get; set; }

        public long? SignInLockOutDurationSeconds { get; set; }
    }
}
