namespace ModelManagement.Core.Data.Data.Model
{
    public class Uploadable : CommonEntity
    {
        public string FileUploadId { get; set; }
        public string PersonId { get; set; }
        public string FileTypeId { get; set; }
        public string MimeTypeId { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public virtual FileType FileType_FileTypeId { get; set; }
        public virtual PersonalInformation PersonalInformation_PersonId { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }

    }
}
