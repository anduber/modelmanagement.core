namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class UplodableListModel
    {
        public string FileUploadId { get; set; }
        public string PersonId { get; set; }
        public string FileTypeId { get; set; }
        public string MimeTypeId { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
    }
}
