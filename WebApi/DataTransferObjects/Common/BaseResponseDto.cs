using Eadent.Common.WebApi.Definitions;
using System.Text.Json.Serialization;

namespace Eadent.Common.WebApi.DataTransferObjects.Common
{
    public class BaseResponseDto
    {
        [JsonPropertyName("developerCode")]
        public long DeveloperCode { get; set; }

        [JsonPropertyName("developerMessage")]
        public string DeveloperMessage { get; set; }

        [JsonPropertyName("generatedInMs")]
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

        public void Set(long developerCode, string developerMessage)
        {
            this.DeveloperCode = developerCode;
            this.DeveloperMessage = developerMessage;
        }
    }
}
