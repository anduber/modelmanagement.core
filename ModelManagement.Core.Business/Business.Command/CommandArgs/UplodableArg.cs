namespace ModelManagement.Core.Business.Business.Command.CommandArgs
{
    public class UploadableArg
    {
        public string FileUploadId { get; set; }
        public string FileTypeId { get; set; }
        public string MimeTypeId { get; set; }
        public byte[] File { get; set; }
    }

    public class ContentArg
    {
        public string ContentId { get; set; }
        public string ContentTypeId { get; set; }
        public string ContentUserId { get; set; }
        public string ContentName { get; set; }
        public string ContentDescription { get; set; }
        public string LongDescription { get; set; }
        public string MimeTypeId { get; set; }
        public byte[] Data { get; set; }


    }
}
