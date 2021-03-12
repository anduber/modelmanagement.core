using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class UserService : AppRepository
    {
        private AppRepository _appRepository;
        private readonly ObjectMapper _mapper;

        public UserService(ModelManagementContext context = null) : base(context)
        {
            var appContext = context ?? new ModelManagementContext();
            _appRepository = new AppRepository(appContext);
            _mapper = new ObjectMapper();
        }

        public User CreateUser(User user, string userName)
        {
            if (User().Find(t => t.PrimaryPhoneNumber == user.PrimaryPhoneNumber) != null)
                throw new InvalidOperationException("User already exsists");
            User().Add(user);
            CreateUserLogin(user, userName);
            AddUserStatus(user.PersonId, user.StatusId, user.UserLoginId);
            return user;
        }

        public CommandResult CreateUser(UserCommandArg userCommandArg)
        {
            if (UserLogin().Find(t => t.UserName == userCommandArg.UserName) != null)
                throw new InvalidOperationException("UserName already exsists");
            var user = AddUser(userCommandArg.UserName, userCommandArg.PrimaryEmail, userCommandArg.PrimaryPhoneNumber,
                userCommandArg.Description, userCommandArg.StatusId);
            var userLogin = AddUserLogin(user.PersonId, DateTime.Now, "N", userCommandArg.Password);
            AddUserRole(user.PersonId, userCommandArg.RoleTypeId, userLogin.UserLoginId);
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
        private User AddUser(string userName, string primaryEmail, string primaryPhoneNumber, string description, string statusId)
        {
            if (string.IsNullOrEmpty(userName)) throw new InvalidOperationException("User name is required!");
            if (UserLogin().Find(t => t.UserName == userName) != null)
                throw new InvalidOperationException("UserName already exsists");
            var user = new User();
            user.SetProperty(primaryEmail, primaryPhoneNumber, description, statusId);
            user.PersonId = Utility.GetId();
            user.UserNumber = Utility.GetUserNumber();
            User().Add(user);
            return user;
        }


        private UserLogin AddUserLogin(string personId, DateTime? fromDate, string requirePaswordChange, string currentPassword)
        {
            var userLogin = new UserLogin();
            userLogin.SetProperty(personId, fromDate, requirePaswordChange, Utility.HashPassword(currentPassword));
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

        public UserLogin CreateUserLogin(User user, string userName)
        {
            var userLogin = new UserLogin
            {
                UserLoginId = Utility.GetId(),
                PersonId = user.PersonId,
                UserName = userName,
                FromDate = DateTime.Now,
                RequirePasswordChange = "Y",
                CurrentPassword = Utility.HashPassword(Utility.DefaultPassword)
            };
            UserLogin().Add(userLogin);
            user.UserLoginId = userLogin.UserLoginId;
            return userLogin;
        }

        public User SetUser(string roleTypeId, string userName, string password, string email, string statusId, string isUserActivated, string primaryPhoneNumber,string taxId)
        {
            return new User
            {
                PersonId = Utility.GetId(),
                UserNumber = Utility.GetUserNumber(),
                //VerificationCode = Utility.GetVerificationCode(),
                PrimaryPhoneNumber = primaryPhoneNumber,
                PrimaryEmail = email,
                IsUserActivated = isUserActivated,
                TaxId = taxId,
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
            personalInfo.CityGeoId = personalInfoArg.CityGeoId;
            personalInfo.CountryGeoId = personalInfoArg.CountryGeoId;
            personalInfo.ExperienceEnumId = personalInfoArg.ExperienceEnumId;           
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
            //var user = SetUser(Utility.RoleTypeModel, personalInfoArg.UserName, Utility.DefaultPassword, null, Utility.StatusDisabled, "Y");
            ////CreateUser(user);
            //var personalInfo = SetPersonalInfo(personalInfoArg, user.PersonId, userLoginId);
            //PersonalInformation().Add(personalInfo);
            //return personalInfo;
            return new PersonalInformation();
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

        public CommandResult UpdatePhysicalInfo(string personId, PhysicalInformationArg physicalInformationArg, string userLoginId)
        {
            var physicalInfo = SetCreateUpdatePhysicalInformation(PhysicalInformation().Find(personId), physicalInformationArg, personId, userLoginId);
            PhysicalInformation().Update(physicalInfo);
            return Utility.CommandSuccess();
        }


        private PhysicalInformation SetCreateUpdatePhysicalInformation(PhysicalInformation physicalInfo, PhysicalInformationArg physicalInfoArg, string personId, string userLoginId)
        {
            if (physicalInfo == null)
            {
                physicalInfo = _mapper.Map<PhysicalInformation>(physicalInfoArg);
                physicalInfo.PersonId = personId;
                physicalInfo.UserLoginId = userLoginId;
                physicalInfo.BmI = UtilityMethods.CalculateBmI(physicalInfo.Height, physicalInfo.Weight);
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
                physicalInfo.BmI = UtilityMethods.CalculateBmI(physicalInfo.Height, physicalInfo.Weight);
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

        public User RegisterModel(PersonalInformationArg personInfoArg, PhysicalInformationArg physicalInfoArg)
        {
            var user =
                CreateUser(
                    SetUser(Utility.RoleTypeModel, personInfoArg.UserName, Utility.DefaultPassword, personInfoArg.Email,
                        Utility.StatusDisabled, "N", personInfoArg.PrimaryPhone,personInfoArg.TaxId), personInfoArg.UserName);
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

        public CommandResult SetVisitor(string visitorId, string userLoginId, string userAgentTypeId, string securityToken, VisitorArg visitorArg)
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
            return Utility.CommandSuccess(SetVisitResult(visit.VisitId, visitor.VisitorId, userAgentTypeId, securityToken));
        }

        protected virtual CommandBase SetVisitResult(string visitId, string visitorId, string userAgentTypeId, string securityToken)
        {
            return new CommandBase
            {
                VisitorId = visitorId,
                VisitId = visitId,
                UserAgentTypeId = userAgentTypeId,
                SecurityToken = string.IsNullOrEmpty(securityToken) ? Utility.GenerateToken(visitorId, visitId) : securityToken
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

       


        //public CommandResult CreateJobOffer(string jobPostId, string modelId, string userLoginId)
        //{
        //    var jobOffer = AddJobOffer(jobPostId, modelId, userLoginId);
        //    return Utility.CommandSuccess(jobOffer.JobOfferId);
        //}

        //internal JobOffer AddJobOffer(string jobPostId, string modelId, string userLoginId)
        //{
        //    var jobOffer = new JobOffer
        //    {
        //        JobOfferId = Utility.GetId(),
        //        OfferedUserId = modelId,
        //        JobPostId = jobPostId,
        //        UserLoginId = userLoginId
        //    };
        //    JobOffer().Add(jobOffer);
        //    return jobOffer;
        //}

        public CommandResult ActivateUserAccount(string userName, string verificationCode,string phoneNumber, string newPassword)
        {
            //var userLogin = UserLogin().FirstOrDefault(t => t.UserName == userName);
            //if (userLogin == null) throw new InvalidOperationException("User not found!");
            //var user = User().Find(userLogin.PersonId);
            //if (user.IsUserActivated == "Y")
            //    throw new InvalidOperationException("User is already activated!");
            //if (verificationCode != user.VerificationCode)
            //    throw new InvalidOperationException("Your verification code is Incorrect!");
            //user.IsUserActivated = "Y";
            //user.StatusId = Utility.StatusEnabled;
            //User().UpdateEntity(user);
            //userLogin.RequirePasswordChange = "N";
            //userLogin.CurrentPassword = Utility.HashPassword(newPassword);
            //UserLogin().UpdateEntity(userLogin);
            var user = User().FirstOrDefault(t => t.PrimaryPhoneNumber == phoneNumber);
            if (user==null) throw new InvalidOperationException("User not found!");
            user.IsUserActivated = "Y";
            user.StatusId = Utility.StatusEnabled;
            user.VerificationCode = verificationCode;
            User().UpdateEntity(user);
            var userLogin = UserLogin().FirstOrDefault(t=>t.PersonId==user.PersonId);
            userLogin.CurrentPassword = Utility.HashPassword(newPassword);
            userLogin.RequirePasswordChange = "N";
            UserLogin().UpdateEntity(userLogin);
            var userLoginCommandResult = new UserLoginCommandResult
            {
                IsLoginSuccess = true,
                RequirePasswordChange = userLogin.RequirePasswordChange,
                IsUserActivated = userLogin.User_PersonId.IsUserActivated,
                SecurityToken = Utility.GetSecurityToken(),
                UserId = userLogin.PersonId,
                UserLoginId = userLogin.UserLoginId,
                UserTypeId = userLogin.UserRoleUserLogin_UserLoginId.FirstOrDefault()?.RoleTypeId
            };
            return Utility.CommandSuccess(userLoginCommandResult);
        }

        public CommandResult AuthenticateUser(string userName, string password,string phoneNumber)
        {
            var userLogin = UserLogin().FirstOrDefault(t => t.User_PersonId.PrimaryPhoneNumber == phoneNumber);
            if (userLogin == null)
                throw new InvalidOperationException("Username or Password Is Incorrect!");
            if (userLogin.User_PersonId.IsUserActivated != "Y" ||
                userLogin.User_PersonId.StatusId != Utility.StatusEnabled) throw new InvalidOperationException("User is not activated!");
            var result = Utility.ValidateHashPassword(password, userLogin?.CurrentPassword);
            if (!result) throw new InvalidOperationException("Username or Password Is Incorrect!");
            if (userLogin.RequirePasswordChange == "Y")
            {
                return Utility.CommandSuccess(new UserLoginCommandResult { IsLoginSuccess = true, RequirePasswordChange = "Y" });
            }
            if (userLogin?.User_PersonId.IsUserActivated != "Y" ||
                userLogin.User_PersonId.StatusId != Utility.StatusEnabled)
                throw new InvalidOperationException("Username or Password Is Incorrect!");
            var userLoginCommandResult = new UserLoginCommandResult
            {
                IsLoginSuccess = true,
                RequirePasswordChange = userLogin.RequirePasswordChange,
                IsUserActivated = userLogin.User_PersonId.IsUserActivated,
                SecurityToken = Utility.GetSecurityToken(),
                UserId = userLogin.PersonId,
                UserLoginId = userLogin.UserLoginId,
                UserTypeId = userLogin.UserRoleUserLogin_UserLoginId.FirstOrDefault()?.RoleTypeId
            };
            return Utility.CommandSuccess(userLoginCommandResult);
        }

        public CommandResult ResetPassword(string email)
        {
            var userLogin = UserLogin().FirstOrDefault(t => t.User_PersonId.PrimaryEmail == email);
            if (userLogin == null) throw new InvalidOperationException("Your email is not registerd!");
            var newPassword = Utility.GetUserNumber();
            userLogin.CurrentPassword = Utility.HashPassword(newPassword);
            userLogin.RequirePasswordChange = "Y";
            UserLogin().Update(userLogin);
            var adminUserLogin = new CommonDataService().GetAdminEmail();
            new CommonDataService().SendEmail(adminUserLogin.EmailId, adminUserLogin.Password, email, "Reset Password",
                "This is your new password \t" + newPassword + "\n http://localhost:4200/#/apps/login");
            return Utility.CommandSuccess(new UserLoginCommandResult(true, "Y", "Y"));
        }

        public CommandResult ChangeUserPassword(string userName, string currentPassword, string newPassword)
        {
            var userLogin = UserLogin().FirstOrDefault(t => t.UserName == userName);
            if (userLogin == null || !Utility.ValidateHashPassword(currentPassword, userLogin.CurrentPassword))
                throw new InvalidOperationException("Username or Password Is Incorrect!");
            userLogin.CurrentPassword = Utility.HashPassword(newPassword);
            userLogin.RequirePasswordChange = "N";
            UserLogin().Update(userLogin);
            var result = new UserLoginCommandResult
            {
                UserId = userLogin.User_PersonId.PersonId,
                UserLoginId = userLogin.UserLoginId,
                SecurityToken = Utility.GetSecurityToken()
            };
            return Utility.CommandSuccess(result);
        }

        public CommandResult ResendActivationCode(string userName)
        {
            var userLogin = UserLogin().FirstOrDefault(t => t.UserName == userName);
            if (userLogin == null)
                throw new InvalidOperationException("User not found. !");
            new CommonDataService().SendActivationCodeViaEmail(userLogin.User_PersonId, userName);
            return Utility.CommandSuccess();
        }

        public User CreateAgent(PersonalInformationArg personInfoArg)
        {
            var user = CreateUser(
                    SetUser(Utility.RoleTypeAgent, personInfoArg.UserName, Utility.DefaultPassword, personInfoArg.Email,
                        Utility.StatusDisabled, "N", personInfoArg.PrimaryPhone,personInfoArg.TaxId), personInfoArg.UserName);
            PersonalInformation().Add(SetPersonalInfo(personInfoArg, user.PersonId, user.UserLoginId));
            if(!string.IsNullOrEmpty(personInfoArg.OfferTypeId))
                SetUserAppl(personInfoArg.OfferTypeId, user.PersonId, user.UserLoginId);
            AddUserRole(user.PersonId, Utility.RoleTypeAgent, user.UserLoginId);
            return user;
        }

        public CommandResult SetUserActivationCode(string userId,string verificationCode)
        {
            var user = User().Find(userId);
            user.VerificationCode = verificationCode;
            User().Update(user);
            return Utility.CommandSuccess();
        }

        public CommandResult CheckUserVerified(string phoneNumber)
        {
            var userFound = User().FirstOrDefault(t => t.PrimaryPhoneNumber == phoneNumber);
            if (userFound == null)
                //return new QueryResult { IsSuccess = false, ErrorMessage = "Your phone number is not registered!" };
                return Utility.CommandError("Your phone number is not registered!");
            if (userFound.IsUserActivated == "Y")
            {
                return Utility.CommandError("Your account is already activated!");
            }
            userFound.VerificationCode = Utility.GetVerificationCode();
            User().Update(userFound);
            return Utility.CommandSuccess(userFound.VerificationCode);
        }

        public Skill AddSkill(string personId,SkillArg skillArg,string userLoginId)
        {
            var personSkill = new Skill
            {
                SkillId = Utility.GetId(),
                SkillTypeId = skillArg.SkillTypeId,
                SkillLevelEnumId = skillArg.SkillLevelEnumId,
                PersonId = personId,
                UserLoginId = userLoginId
            };
            Skill().Add(personSkill);
            return personSkill;
        }

        public void AddSkills(List<SkillArg> skillArgs,string personId,string userLoginId)
        {
            foreach (var skill in skillArgs)
            {
                AddSkill(personId, skill, userLoginId);
            }
        }
    }
}
