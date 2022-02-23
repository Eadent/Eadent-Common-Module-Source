namespace Eadent.Common.WebApi.DataTransferObjects.Sessions.Users
{
    public class UserSessionSignInRequestDto
    {
        public string eMailAddress { get; set; }

        public string plainTextPassword { get; set; }
    }
}
