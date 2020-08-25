using System.Collections.Generic;

namespace ModelManagement.Core.Data.Data.Model
{
    public class StatusItem : Entity
    {
        public StatusItem()
        {
            UserId_Users = new List<User>();
            UserStatusId_UserStatuses = new List<UserStatus>();
            StatusItem_RoleTypes = new List<RoleType>();
            StatusItem_JobOffers = new List<JobOffer>();
            StatusItem_JobApplications = new List<JobApplication>();
            StatusItem_JobPostes = new List<JobPost>();
        }
        public string StatusId { get; set; }
        public string StatusTypeId { get; set; }
        public string Description { get; set; }
        public string SequenceId { get; set; }
        public string IsActive { get; set; }
        public virtual List<User> UserId_Users { get; set; }
        public virtual List<UserStatus> UserStatusId_UserStatuses{ get; set; }
        public virtual List<RoleType> StatusItem_RoleTypes { get; set; }
        public virtual List<JobOffer> StatusItem_JobOffers { get; set; }
        public virtual StatusType StatusItem_StatusType { get; set; }
        public virtual List<JobApplication> StatusItem_JobApplications { get; set; }
        public virtual List<JobPost> StatusItem_JobPostes { get; set; }

    }
}
