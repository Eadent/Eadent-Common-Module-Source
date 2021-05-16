namespace Eadent.Common.WebApi.DataTransferObjects.FileTransfers
{
    public class FileUploadRequestDto
    {
        public string Format { get; set; }
        public string RelativePath { get; set; }
        public string FileName { get; set; }

        public long TotalFileSize { get; set; }
        public long StandardBlockSize { get; set; }
        public long TotalNumBlocks { get; set; }

        public long SizeBeforeThisBlock { get; set; }
        public long SizeAfterThisBlock { get; set; }

        public long BlockIndex { get; set; }
        public long ThisBlockSize { get; set; }
        public string BlockBase64 { get; set; }

        public string BlockHashType { get; set; }
        public string BlockHashBase64 { get; set; }
    }
}
