﻿namespace Eadent.Common.WebApi.Definitions
{
    public enum DeveloperCode : long
    {
        Error = 0,

        Success = 1000,

        // Authentication/Authorisation.
        Unauthorised = 2000,

        // User Sessions.
        SuccessUserMustChangePassword = 3000,
        UserLockedOut = 3001,
        SessionTimedOutExpired = 3002,
        SessionSignedOut = 3003
    }
}
