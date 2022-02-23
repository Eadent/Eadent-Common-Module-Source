namespace Eadent.Common.WebApi.DataTransferObjects.Sessions.Users
{
    public class UserSessionSignInRequestDto
    {
        public string EMailAddress { get; set; }

        public string PlainTextPassword { get; set; }
    }
}
