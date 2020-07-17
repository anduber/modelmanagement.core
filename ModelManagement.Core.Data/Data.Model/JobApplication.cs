using System;

namespace ModelManagement.Core.Data.Data.Model
{
    public class JobApplication:Entity
    {
        public string JobApplicationId { get; set; }
        public string JobPostId { get; set; }
        public string ApplyingUserId { get; set; }
        public string StatusId { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public virtual JobPost JobApplication_JobPost { get; set; }
        public virtual User JobApplication_ApplyingUser { get; set; }
        public virtual StatusItem JobApplication_StatusItem { get; set; }


    }
}
