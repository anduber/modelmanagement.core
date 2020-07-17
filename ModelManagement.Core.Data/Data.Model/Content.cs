namespace ModelManagement.Core.Data.Data.Model
{
    public class Content : Entity
    {
        public string ContentId { get; set; }
        public string ContentTypeId { get; set; }
        public string ContentUserId { get; set; }
        public string ContentName { get; set; }
        public string ContentDescription { get; set; }
        public string LongDescription { get; set; }
        public string MimeTypeId { get; set; }
        public virtual ContentType ContentType_ContentTypeId { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }
        //public virtual UserLogin UserLoginId_LastUpdatedByUserLogin { get; set; }
        public virtual User User_ContentUserId { get; set; }
    }
}
