using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class UserLogin : CommonEntity
    {
        public UserLogin()
        {
            PersonalInformationUserLogin_PersonId = new List<PersonalInformation>();
            PhysicalInformationUserLogin_PersonId = new List<PhysicalInformation>();
            CategoryUserLogin_PersonId = new List<Category>();
            ContactInformationUserLogin_PersonId = new List<ContactInformation>();
            UploadableUserLogin_PersonId = new List<Uploadable>();
            UserLoginPasswordHistory_UserLoginId = new List<UserLoginPasswordHistory>();
            UserStatus_StatusId = new List<UserStatus>();
            VisitorUserLogin_PersonId = new List<Visitor>();
            OfferItemTypeUserLogin_UserLoginId = new List<OfferItemType>();
            OfferItemTypeMapUserLogin_UserLoginId = new List<OfferItemTypeMap>();
            UserLogin_JobPostUserLogin = new List<JobPost>();
            UserLogin_JobOfferUserLogin = new List<JobOffer>();
        }
        public string PersonId { get; set; }
        public string UserName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ThruDate { get; set; }
        public string CurrentPassword { get; set; }
        public string PasswordHint { get; set; }
        public string RequirePasswordChange { get; set; }
        public int? SuccessiveFailedLogins { get; set; }
        public string HasLoggedOut { get; set; }
        public virtual User User_PersonId { get; set; }
        public virtual List<PersonalInformation> PersonalInformationUserLogin_PersonId { get; set; }
        public virtual List<UserAppl> UserApplUserLogin_UserId { get; set; }
        public virtual List<PhysicalInformation> PhysicalInformationUserLogin_PersonId { get; set; }
        public virtual List<Category> CategoryUserLogin_PersonId { get; set; }
        public virtual List<ContactInformation> ContactInformationUserLogin_PersonId { get; set; }
        public virtual List<Uploadable> UploadableUserLogin_PersonId { get; set; }
        public virtual List<UserLoginPasswordHistory> UserLoginPasswordHistory_UserLoginId { get; set; }
        public virtual List<OfferType> OfferTypeUserLogin_UserLoginId { get; set; }
        public virtual List<OfferItemType> OfferItemTypeUserLogin_UserLoginId { get; set; }
        public virtual List<OfferItemTypeMap> OfferItemTypeMapUserLogin_UserLoginId { get; set; }
        public virtual List<UserRole> UserRoleUserLogin_UserLoginId { get; set; }
        public virtual List<UserStatus> UserStatus_StatusId { get; set; }
        public virtual List<Visitor> VisitorUserLogin_PersonId { get; set; }
        public virtual List<JobPost> UserLogin_JobPostUserLogin { get; set; }
        public virtual List<JobOffer> UserLogin_JobOfferUserLogin { get; set; }

        public void SetProperty(string personId,DateTime? fromDate,string requirePasswordChange,string currentPassword)
        {
            PersonId = personId;
            FromDate = fromDate;
            RequirePasswordChange = requirePasswordChange;
            CurrentPassword = currentPassword;
        }

    }
}
