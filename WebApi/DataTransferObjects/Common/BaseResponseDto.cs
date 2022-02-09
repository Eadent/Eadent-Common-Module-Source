using Eadent.Common.WebApi.Definitions;

namespace Eadent.Common.WebApi.DataTransferObjects.Common
{
    public class BaseResponseDto
    {
        public long DeveloperCode { get; private set; }

        public string DeveloperMessage { get; private set; }

        public long GeneratedInMs { get; set; }

        public BaseResponseDto()
        {
            SetError();
        }

        public void SetError()
        {
            DeveloperCode = (long)CommonDeveloperCode.Error;
            DeveloperMessage = "Error.";
        }

        public void SetUnauthorised()
        {
            DeveloperCode = (long)CommonDeveloperCode.Unauthorised;
            DeveloperMessage = "Unauthorised.";
        }

        public void SetSuccess()
        {
            DeveloperCode = (long)CommonDeveloperCode.Success;
            DeveloperMessage = "Success.";
        }

        public void Set(CommonDeveloperCode developerCode, string developerMessage)
        {
            DeveloperCode = (long)developerCode;
            DeveloperMessage = developerMessage;
        }
    }
}
