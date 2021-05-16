using Eadent.Common.WebApi.Definitions;

namespace Eadent.Common.WebApi.DataTransferObjects.Common
{
    public class BaseResponseDto
    {
        public DeveloperCode DeveloperCode { get; set; }

        public string DeveloperMessage { get; set; }

        public long GeneratedInMs { get; set; }

        public BaseResponseDto()
        {
            DeveloperCode = DeveloperCode.Success;
            DeveloperMessage = "Success.";
        }
    }
}
