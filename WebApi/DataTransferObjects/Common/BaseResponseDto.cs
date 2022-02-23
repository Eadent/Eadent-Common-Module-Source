using Eadent.Common.WebApi.Definitions;

namespace Eadent.Common.WebApi.DataTransferObjects.Common
{
    public class BaseResponseDto
    {
        public long developerCode { get; private set; }

        public string developerMessage { get; private set; }

        public long GeneratedInMs { get; set; }

        public BaseResponseDto()
        {
            SetError();
        }

        public void SetError()
        {
            developerCode = (long)CommonDeveloperCode.Error;
            developerMessage = "Error.";
        }

        public void SetUnauthorised()
        {
            developerCode = (long)CommonDeveloperCode.Unauthorised;
            developerMessage = "Unauthorised.";
        }

        public void SetSuccess()
        {
            developerCode = (long)CommonDeveloperCode.Success;
            developerMessage = "Success.";
        }

        public void Set(long developerCode, string developerMessage)
        {
            this.developerCode = developerCode;
            this.developerMessage = developerMessage;
        }
    }
}
