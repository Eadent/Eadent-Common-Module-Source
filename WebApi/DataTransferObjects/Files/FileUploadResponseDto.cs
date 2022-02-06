using Eadent.Common.WebApi.DataTransferObjects.Common;

namespace Eadent.Common.WebApi.DataTransferObjects.Files
{
    public class FileUploadResponseDto : BaseResponseDto
    {
        public long DestinationFileSizeBeforeThisChunk { get; set; }

        public long DestinationFileSizeAfterThisChunk { get; set; }
    }
}
