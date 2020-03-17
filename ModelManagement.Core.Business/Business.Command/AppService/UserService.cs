using System;
using System.Collections.Generic;
using System.Linq;
using ModelManagement.Core.Business.Business.Command.CommandArgs;
using ModelManagement.Core.Business.Business.Command.EntityRepositories;
using ModelManagement.Core.Business.Business.Command.Utils;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Data.Data.Model;

namespace ModelManagement.Core.Business.Business.Command.AppService
{
    public class UserService:AppRepository
    {
        public ModelManagementContext _context;
        private AppRepository _appRepository;
        private readonly ObjectMapper _mapper;

        public UserService(ModelManagementContext context = null):base(context)
        {
            _context = context ?? new ModelManagementContext();
            _mapper = new ObjectMapper();
            _appRepository = new AppRepository(_context);
        }

        public User CreateUser(User user)
        {
            if (User().Find(t => t.UserName == user.UserName) != null)
                throw new InvalidOperationException("UserName already exsists");
            User().Add(user);
            CreateUserLogin(user);
            AddUserStatus(user.PersonId, user.StatusId, user.UserLoginId);
            return user;
        }

        public CommandResult CreateUser(UserCommandArg userCommandArg)
        {
            if (User().Find(t => t.UserName == userCommandArg.UserName) != null)
                throw new InvalidOperationException("UserName already exsists");
            var user = AddUser(userCommandArg.UserName, userCommandArg.PrimaryEmail, userCommandArg.PrimaryPhoneNumber,
                userCommandArg.Description, userCommandArg.StatusId);
            var userLogin = AddUserLogin(user.PersonId, DateTime.Now, "N", userCommandArg.Password);
            AddUserRole(user.PersonId,userCommandArg.RoleTypeId,userLogin.UserLoginId);
            return Utility.CommandSuccess(user.PersonId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="primaryEmail"></param>
        /// <param name="primaryPhoneNumber"></param>
        /// <param name="description"></param>
        /// <param name="statusId"></param>
        /// <returns></returns>
        private User AddUser(string userName,string primaryEmail,string primaryPhoneNumber,string description,string statusId)
        {
            if(string.IsNullOrEmpty(userName)) throw new InvalidOperationException("User name is required!");
            if (User().Find(t => t.UserName == userName) != null)
                throw new InvalidOperationException("UserName already exsists");
            var user = new User();
            user.SetProperty(userName,primaryEmail,primaryPhoneNumber,description,statusId);
            user.PersonId = Utility.GetId();
            user.UserNumber = Utility.GetUserNumber();
            User().Add(user);
            return user;
        }

        
        private UserLogin AddUserLogin(string personId,DateTime? fromDate,string requirePaswordChange,string currentPassword)
        {
            var userLogin = new UserLogin();
            userLogin.SetProperty(personId,fromDate,requirePaswordChange, Utility.HashPassword(currentPassword));
            userLogin.UserLoginId = Utility.GetId();
            UserLogin().Add(userLogin);
            return userLogin;
        }
        public void RemoveUser(string personId)
        {
            var user = User().FirstOrDefault(t => t.PersonId == personId);
            var userLogin = user.User_UserLogin.FirstOrDefault();
            User().Remove(user);
            UserLogin().Remove(userLogin);
        }

        public bool DeleteUser(User user)
        {
            return User().Delete(user);
        }

        public UserLogin CreateUserLogin(User user)
        {
            var userLogin = new UserLogin
            {
                UserLoginId = Utility.GetId(),
                PersonId = user.PersonId,
                FromDate = DateTime.Now,
                RequirePasswordChange = "Y",
                CurrentPassword = Utility.HashPassword(Utility.DefaultPassword)
            };
            UserLogin().Add(userLogin);
            user.UserLoginId = userLogin.UserLoginId;
            return userLogin;
        }

        public User SetUser(string roleTypeId, string userName, string password, string email, string statusId)
        {
            return new User
            {
                PersonId = Utility.GetId(),
                UserNumber = Utility.GetUserNumber(),
                //RoleTypeId = roleTypeId,
                UserName = userName,
                //Password = string.IsNullOrEmpty(password) ? null : Utility.HashPassword(password),
                PrimaryEmail = email,
                StatusId = string.IsNullOrEmpty(statusId) ? Utility.StatusDisabled : statusId
            };
        }

        public PersonalInformation SetPersonalInfo(PersonalInformationArg personalInfoArg, string personId, string userLoginId)
        {
            var personalInfo = PersonalInformation().Find(t => t.PersonId == personId);
            if (personalInfo == null)
            {
                personalInfo = _mapper.Map<PersonalInformation>(personalInfoArg);
                personalInfo.UserLoginId = userLoginId;
                personalInfo.PersonId = personId;
                return personalInfo;
            }
            personalInfo.FirstName = personalInfoArg.FirstName;
            personalInfo.FatherName = personalInfoArg.FatherName;
            personalInfo.LastName = personalInfoArg.LastName;
            personalInfo.DateOfBirth = personalInfoArg.DateOfBirth;
            personalInfo.Sex = personalInfoArg.Sex;
            personalInfo.MaritialStatusEnumId = personalInfoArg.MaritialStatusEnumId;
            personalInfo.UserLoginId = userLoginId;
            personalInfo.PersonId = personId;
            personalInfo.GeoId = personalInfoArg.GeoId;
            return personalInfo;
        }

        public User UpdateUser(string personId, string roleTypeId, string email)
        {
            var user = User().Find(t => t.PersonId == personId);
            //user.RoleTypeId = roleTypeId;
            user.PrimaryEmail = email;
            User().Update(user);
            return user;
        }

        public PersonalInformation CreatePersonalInfo(PersonalInformationArg personalInfoArg, string userLoginId)
        {
            var user = SetUser(Utility.RoleTypeModel, personalInfoArg.UserName, Utility.DefaultPassword, null, Utility.StatusDisabled);
            CreateUser(user);
            var personalInfo = SetPersonalInfo(personalInfoArg, user.PersonId, userLoginId);
            PersonalInformation().Add(personalInfo);
            return personalInfo;
        }

        public PersonalInformation UpdatePersonalInfo(PersonalInformationArg personalInfoArg, string personId, string userLoginId)
        {
            var personalInfo = SetPersonalInfo(personalInfoArg, personId, userLoginId);
            PersonalInformation().UpdateEntity(personalInfo);
            return personalInfo;
        }

        public PhysicalInformation CreateUpdatePhysicalInfo(PhysicalInformationArg physicalInfoArg, string personId, string userLoginId)
        {
            var physicalInfo = PhysicalInformation().FirstOrDefault(t => t.PersonId == personId);
            return SetCreateUpdatePhysicalInformation(physicalInfo, physicalInfoArg, personId, userLoginId);
        }

        private PhysicalInformation SetCreateUpdatePhysicalInformation(PhysicalInformation physicalInfo, PhysicalInformationArg physicalInfoArg, string personId, string userLoginId)
        {
            if (physicalInfo == null)
            {
                physicalInfo = _mapper.Map<PhysicalInformation>(physicalInfoArg);
                physicalInfo.PersonId = personId;
                physicalInfo.UserLoginId = userLoginId;
                PhysicalInformation().Add(physicalInfo);
            }
            else
            {
                physicalInfo.Bust = physicalInfoArg.Bust;
                physicalInfo.Complexion = physicalInfoArg.Complexion;
                physicalInfo.DressSize = physicalInfoArg.DressSize;
                physicalInfo.ShoeSize = physicalInfoArg.ShoeSize;
                physicalInfo.EyeColor = physicalInfoArg.EyeColor;
                physicalInfo.HairColor = physicalInfoArg.HairColor;
                physicalInfo.Height = physicalInfoArg.Height;
                physicalInfo.HeightEnumId = physicalInfoArg.HeightEnumId;
                physicalInfo.Hip = physicalInfoArg.Hip;
                physicalInfo.Waist = physicalInfoArg.Waist;
                physicalInfo.Weight = physicalInfoArg.Weight;
                physicalInfo.WeightEnumId = physicalInfoArg.WeightEnumId;
                physicalInfo.UserLoginId = userLoginId;
                PhysicalInformation().UpdateEntity(physicalInfo);
            }
            return physicalInfo;
        }

        public void ChangeUserStatus(string personId, string statusId, string userLoginId)
        {
            var user = User().FirstOrDefault(t => t.PersonId == personId);
            user.StatusId = statusId;
            User().UpdateEntity(user);
            AddUserStatus(personId, statusId, userLoginId);
        }

        public void AddUserStatus(string personId, string statusId, string userLoginId)
        {
            var userStatus = new UserStatus
            {
                UserStatusId = Utility.GetId(),
                UserId = personId,
                StatusId = statusId,
                UserLoginId = userLoginId
            };
            UserStatus().Add(userStatus);
        }

        public bool ChangeUserPassword(string personId, string currentPassword, string newPassword)
        {
            //var user = UserRepository().FirstOrDefault(t => t.PersonId == personId);
            //if (!Utility.ValidateHashPassword(currentPassword, user.Password)) return false;
            //user.Password = Utility.HashPassword(newPassword);
            //UserRepository().Update(user);
            return true;
        }

        public bool AuthenticateUser(string userName, string password)
        {
            var _password = Utility.HashPassword(password);
            var user = User().FirstOrDefault(t => t.UserName == userName && t.StatusId == Utility.StatusEnabled);
            return user != null;
        }

        private string SetBodySizeType(PhysicalInformationArg physicalInfoArg)
        {
            return "FIT";
        }

        public User RegisterModel(PersonalInformationArg personInfoArg, PhysicalInformationArg physicalInfoArg)
        {
            var user = CreateUser(SetUser(Utility.RoleTypeModel, personInfoArg.UserName, Utility.DefaultPassword, personInfoArg.Email, Utility.StatusDisabled));
            PersonalInformation().Add(SetPersonalInfo(personInfoArg, user.PersonId, user.UserLoginId));
            SetCreateUpdatePhysicalInformation(null, physicalInfoArg, user.PersonId, user.UserLoginId);
            SetUserAppl(personInfoArg.OfferTypeId, user.PersonId, user.UserLoginId);
            AddUserRole(user.PersonId, Utility.RoleTypeModel, user.UserLoginId);
            return user;
        }

        public void SetUserAppl(string offerTypeId, string userId, string userLoginId)
        {
            var userType = OfferType().Find(t => t.OfferTypeId == offerTypeId);
            var userAppl = new UserAppl
            {
                UserId = userId,
                OfferTypeId = offerTypeId,
                FromDate = DateTime.Now,
                ThruDate = userType.ValidNoOfDays == null ? null : (DateTime?)DateTime.Now.AddDays((double)userType.ValidNoOfDays),
                UserLoginId = userLoginId
            };
            UserAppl().Add(userAppl);
        }

        public void AddUserRole(string userId, string roleTypeId, string userLoginId, bool create = false)
        {
            var userRole = new UserRole
            {
                UserId = userId,
                RoleTypeId = roleTypeId,
                UserLoginId = userLoginId
            };
            if (create)
            {
                UserRole().Create(userRole);
            }
            else
            {
                UserRole().Add(userRole);
            }

        }


        public CommandResult CreateContactInfo(string personId, ContactInfoArg contactInfoArg, string userLoginId)
        {
            var contactInfo = new ContactInformation
            {
                PersonId = personId,
                ContactMechTypeId = contactInfoArg.ContactMechTypeId,
                ContactUrl = contactInfoArg.ContactUrl,
                UserLoginId = userLoginId
            };
            ContactInfo().Create(contactInfo);
            return Utility.CommandSuccess();
        }

        public CommandResult SetVisitor(string visitorId, string userLoginId, string userAgentTypeId,string securityToken, VisitorArg visitorArg)
        {
            
            var visitor = new Visitor();
            if (!CheckVisitorExists(visitorId))
            {
                visitor = AddNewVisitor(userLoginId, userAgentTypeId, visitorArg);
            }
            else
            {
                visitor.VisitorId = visitorId;
            }
            var visit = AddVisit(visitor.VisitorId, userLoginId, visitorArg);
            return Utility.CommandSuccess(SetVisitResult(visit.VisitId,visitor.VisitorId,userAgentTypeId,securityToken));
        }

        protected virtual CommandBase SetVisitResult(string visitId,string visitorId,string userAgentTypeId,string securityToken)
        {
            return new CommandBase
            {
                VisitorId = visitorId,
                VisitId = visitId,
                UserAgentTypeId = userAgentTypeId,
                SecurityToken = string.IsNullOrEmpty(securityToken)?Utility.GenerateToken(visitorId,visitId):securityToken
            };
        }



        private bool CheckVisitorExists(string visitorId)
        {
            return !string.IsNullOrEmpty(visitorId) && Visitor().Find(t => t.VisitorId == visitorId) != null;
        }

        internal Visitor AddNewVisitor(string userLoginId, string userAgentTypeId, VisitorArg visitorArg)
        {
            var visitor = new Visitor
            {
                VisitorId = Utility.GetId(),
                UserLoginId = userLoginId,
                UserAgentTypeId = userAgentTypeId
            };
            Visitor().Add(visitor);
            return visitor;
        }

        internal Visit AddVisit(string visitorId, string userLoginId, VisitorArg visitorArg)
        {
            var visit = new Visit
            {
                VisitId = Utility.GetId(),
                VisitorId = visitorId,
                UserLoginId = userLoginId
            };
            Visit().Add(visit);
            return visit;
        }

        public CommandResult CreateJobPost(JobPostCommandArg jobPostCommandArg, List<string> modelIds, string userLoginId)
        {
            var jobPost = new JobPost();
            jobPost.SetProperty(jobPostCommandArg.UserId, jobPostCommandArg.JobTitle, jobPostCommandArg.JobDescription,
                jobPostCommandArg.JobDueDate, jobPostCommandArg.PaymentMethodEnumId, jobPostCommandArg.JobLocationGeoId,
                jobPostCommandArg.AgentJobEnumId, jobPostCommandArg.AgentLocationGeoId);
            jobPost.JobPostId = Utility.GetId();
            jobPost.UserLoginId = userLoginId;
            jobPost.IsActive = "Y";
            JobPost().Add(jobPost);
            if(modelIds.Count>0)
            {
                foreach (var model in modelIds)
                {
                    AddJobOffer(jobPost.JobPostId, model, userLoginId);
                }
            }
            return Utility.CommandSuccess(jobPost.JobPostId);
        }

       
        public CommandResult CreateJobOffer(string jobPostId,string modelId,string userLoginId)
        {
            var jobOffer = AddJobOffer(jobPostId, modelId, userLoginId);
            return Utility.CommandSuccess(jobOffer.JobOfferId);
        }

        internal JobOffer AddJobOffer(string jobPostId,string modelId,string userLoginId)
        {
            var jobOffer = new JobOffer
            {
                JobOfferId = Utility.GetId(),
                ModelUserId=modelId,
                JobPostId = jobPostId,
                UserLoginId = userLoginId
            };
            JobOffer().Add(jobOffer);
            return jobOffer;
        }
    }
}
