namespace ModelManagement.Core.Data.Data.Model
{
    public class JobPostDetail:Entity
    {
        public string JobPostId { get; set; }
        public string JobPostSeqId { get; set; }
        public string ApplicationsOnMedia { get; set; }
        public virtual JobPost JobPostDeail_JobPost{ get; set; }
    }
}