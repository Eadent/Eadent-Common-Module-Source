namespace Eadent.Common.WebApi.DataTransferObjects.Files
{
    public class FileUploadRequestDto
    {
        public string FileFormat { get; set; }

        public string SourcePath { get; set; }

        public string DestinationRelativePath { get; set; }

        public string FileName { get; set; }

        public long TotalFileSize { get; set; }

        public long ChunkOffset { get; set; }

        public long ChunkSize { get; set; }

        public string ChunkBase64 { get; set; }

        public string ChunkHashType { get; set; }

        public string ChunkHashBase64 { get; set; }
    }
}
