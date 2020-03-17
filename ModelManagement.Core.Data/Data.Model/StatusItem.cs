using System.Collections.Generic;

namespace ModelManagement.Core.Data.Data.Model
{
    public class StatusItem : CommonEntity
    {
        public StatusItem()
        {
            UserId_Users = new List<User>();
            UserStatusId_UserStatuses = new List<UserStatus>();
            StatusItem_RoleTypes = new List<RoleType>();
            StatusItem_JobOffers = new List<JobOffer>();
        }
        public string StatusId { get; set; }
        public string Description { get; set; }
        public virtual List<User> UserId_Users { get; set; }
        public virtual List<UserStatus> UserStatusId_UserStatuses{ get; set; }
        public virtual List<RoleType> StatusItem_RoleTypes { get; set; }
        public virtual List<JobOffer> StatusItem_JobOffers { get; set; }
    }
}
