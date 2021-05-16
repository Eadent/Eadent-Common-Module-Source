using Eadent.Common.WebApi.Definitions;

namespace Eadent.Common.WebApi.DataTransferObjects.Common
{
    public class BaseResponseDto
    {
        public DeveloperCode DeveloperCode { get; private set; }

        public string DeveloperMessage { get; private set; }

        public long GeneratedInMs { get; set; }

        public BaseResponseDto()
        {
            SetError();
        }

        public void SetError()
        {
            DeveloperCode = DeveloperCode.Error;
            DeveloperMessage = "Error.";
        }

        public void SetUnauthorised()
        {
            DeveloperCode = DeveloperCode.Unauthorised;
            DeveloperMessage = "Unauthorised.";
        }

        public void SetSuccess()
        {
            DeveloperCode = DeveloperCode.Success;
            DeveloperMessage = "Success.";
        }

        public void Set(DeveloperCode developerCode, string developerMessage)
        {
            DeveloperCode = developerCode;
            DeveloperMessage = developerMessage;
        }
    }
}
