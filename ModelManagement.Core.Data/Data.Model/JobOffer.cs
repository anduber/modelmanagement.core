namespace ModelManagement.Core.Data.Data.Model
{
    public class JobOffer:CommonEntity
    {
        public string JobOfferId { get; set; }
        public string JobPostId { get; set; }
        public string ModelUserId { get; set; }
        public string StatusId { get; set; }
        public string IsSeen { get; set; }
        public virtual JobPost JobPost_JobOfferId { get; set; }
        public virtual StatusItem JobPost_StatusId { get; set; }
        public virtual User JobOffer_ModelUserId { get; set; }
        public virtual UserLogin JobOffer_UserLoginId { get; set; }
    }
}
