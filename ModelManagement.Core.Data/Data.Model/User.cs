using System.Collections.Generic;

namespace ModelManagement.Core.Data.Data.Model
{
    public class User : CommonEntity
    {
        public User()
        {
            User_UserLogin = new List<UserLogin>();
            UserApplId_UserAppls = new List<UserAppl>();
            UserRoleId_UserRoles = new List<UserRole>();
            UserStatusId_UserStatuses = new List<UserStatus>();
            User_JobPosts = new List<JobPost>();
            User_JobOffers = new List<JobOffer>();
        }
        public string PersonId { get; set; }
        public string UserNumber { get; set; }
        //public string UserName { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string Description { get; set; }
        public string StatusId { get; set; }
        public string IsUserActivated { get; set; }
        public string VerificationCode { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }
        public virtual List<UserAppl> UserApplId_UserAppls { get; set; }
        public virtual StatusItem StatusId_StatusItem { get; set; }
        public virtual List<UserRole> UserRoleId_UserRoles { get; set; }
        public virtual List<UserLogin> User_UserLogin { get; set; }
        public virtual List<UserStatus> UserStatusId_UserStatuses{ get; set; }
        public virtual List<JobPost> User_JobPosts{ get; set; }
        public virtual List<JobOffer> User_JobOffers{ get; set; }

        public void SetProperty(string primaryEmail, string primaryPhoneNumber, string description, string statusId)
        {
            //UserName = userName;
            PrimaryEmail = primaryEmail;
            PrimaryPhoneNumber = PrimaryPhoneNumber;
            Description = description;
            StatusId = statusId;
        }
    }
}
