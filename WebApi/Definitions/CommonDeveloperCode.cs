namespace Eadent.Common.WebApi.Definitions
{
    public enum CommonDeveloperCode : long
    {
        Success = 1000,

        Error = 2000,

        // General.
        MissingRequestBody = 3000,

        // Authentication/Authorisation.
        Unauthorised = 4000,

        // User Sessions.
        SuccessUserMustChangePassword = 5000,
        UserLockedOut = 5001,
        SessionTimedOutExpired = 5002,
        SessionSignedOut = 5003,
        InvalidDisplayName = 5004,
        InvalidEMailAddress = 5005,
        InvalidPassword = 5006,
        UserAlreadyExists = 5007
    }
}
