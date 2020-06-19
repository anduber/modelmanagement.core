using System;
using ModelManagement.Core.Business.Business.Command.Utils;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using System.Collections.Generic;
using ModelManagement.Core.Business.Business.Command.AppService;
using ModelManagement.Core.Business.Business.Command.CommandArgs;

namespace ModelManagement.Core.Business.Business.Command
{

    public class CreateUserCommand : CommandBase, ICommand
    {
        public UserCommandArg UserCommandArg { get; set; }
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var result = new UserService(transaction.Context).CreateUser(UserCommandArg);
                transaction.CompleteTransaction();
                return result;
            }
        }
    }

    public class UpdateUserCommand : CommandBase, ICommand
    {
        public string PersonId { get; set; }
        public string Email { get; set; }
        public string RoleTypeId { get; set; }

        public CommandResult Execute()
        {
            var service = new UserService();
            var user = service.UpdateUser(PersonId, RoleTypeId, Email);
            return Utility.CommandSuccess();
        }
    }        

    public class RemoveUserCommand : CommandBase, ICommand
    {
        public string PersonId;
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var userService = new UserService(transaction.Context);
                userService.RemoveUser(PersonId);
                transaction.CompleteTransaction();
                return Utility.CommandSuccess();
            }
        }
    }

    public class ChangeUserStatusCommand : CommandBase, ICommand
    {
        public string PersonId { get; set; }
        public string StatusId { get; set; }

        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var userService = new UserService(transaction.Context);
                userService.ChangeUserStatus(PersonId, StatusId, UserLoginId);
                transaction.CompleteTransaction();
                return Utility.CommandSuccess();
            }
        }
    }

    public class CreatePersonalInformationCommand : CommandBase, ICommand
    {
        public PersonalInformationArg PersonalInformationArg { get; set; }
        public List<string> CategoryIds { get; set; }
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var userService = new UserService(transaction.Context);
                var categoryService = new CategoryService(transaction.Context);
                var personalInfo = userService.CreatePersonalInfo(PersonalInformationArg, UserLoginId);
                categoryService.CreateCategories(CategoryIds, personalInfo.PersonId, UserLoginId);
                transaction.CompleteTransaction();
                return Utility.CommandSuccess(personalInfo.PersonId);
            }
        }
    }

    public class UpdatePersonalInformationCommand : CommandBase, ICommand
    {
        public string PersonId { get; set; }
        public PersonalInformationArg PersonalInformationArg { get; set; }
        public UploadableArg UplodableArg { get; set; }
        public List<string> CategoryTypeIds { get; set; }

        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {

                var userService = new UserService(transaction.Context);
                var categoryService = new CategoryService(transaction.Context);
                var uplodableService = new FileUploadService(transaction.Context);
                userService.UpdatePersonalInfo(PersonalInformationArg, PersonId, UserLoginId);
                if (CategoryTypeIds != null)
                {
                    categoryService.UpdateCategories(CategoryTypeIds, PersonId, UserLoginId);
                }
                if (UplodableArg != null)
                {
                    uplodableService.SaveUplodable(UplodableArg, PersonId, UserLoginId);
                }
                transaction.CompleteTransaction();
                return Utility.CommandSuccess();
            }
        }
    }

    public class CreateUpdatePhysicalInformationCommand : CommandBase, ICommand
    {
        public string PersonId { get; set; }
        public PhysicalInformationArg PhysicalInformationArg { get; set; }
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var userService = new UserService(transaction.Context);
                userService.CreateUpdatePhysicalInfo(PhysicalInformationArg, PersonId, UserLoginId);
                transaction.CompleteTransaction();
                return Utility.CommandSuccess();
            }
        }
    }

    public class ChangeUserPasswordCommand : CommandBase, ICommand
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        public CommandResult Execute()
        {
            return new UserService().ChangeUserPassword(UserName,CurrentPassword,NewPassword);
        }
    }

    public class AuthenticateUserCommand : CommandBase, ICommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public CommandResult Execute()
        {
            //var userService = new UserService();
            //var result = userService.AuthenticateUser(UserName, Password);
            //return result ? Utility.CommandSuccess(Utility.GetSecurityToken()) : Utility.CommandError("Username or Password Is Incorrect!");
            return new CommandResult();
        }
    }

    public class AddUserRoleCommand : CommandBase, ICommand
    {
        public string UserId { get; set; }
        public string RoleTypeId { get; set; }
        public CommandResult Execute()
        {
            new UserService().AddUserRole(UserId, RoleTypeId, UserLoginId, true);
            return Utility.CommandSuccess();
        }
    }


    public class RegisterModelCommand : CommandBase, ICommand
    {
        public PersonalInformationArg PersonalInformationArg { get; set; }
        public PhysicalInformationArg PhysicalInformationArg { get; set; }
        public List<ContactInfoArg> ContactInfoArgs { get; set; }
        public List<string> CategoryTypeIds { get; set; }
        public List<UploadableArg> UploadableArgs { get; set; }

        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var userService = new UserService(transaction.Context);
                var categoryService = new CategoryService(transaction.Context);
                var contactService = new ContactService(transaction.Context);
                var fileUploadService = new FileUploadService(transaction.Context);

                var user = userService.RegisterModel(PersonalInformationArg, PhysicalInformationArg);
                categoryService.CreateCategories(CategoryTypeIds, user.PersonId, user.UserLoginId);
                contactService.CreateContactInfos(ContactInfoArgs, user.PersonId, user.UserLoginId);
                fileUploadService.AddAUploadables(UploadableArgs,user.PersonId,user.UserLoginId);

                transaction.CompleteTransaction();

                try
                {
                    var commonService = new CommonDataService();
                    commonService.SendActivationCodeViaEmail(user, PersonalInformationArg.UserName);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Error while sending email!");
                }

               
                return Utility.CommandSuccess(user.UserNumber);
            }
        }
    }

    public class CreateContactCommand:CommandBase,ICommand
    {
        public string PersonId { get; set; }
        public ContactInfoArg ContactInfoArg { get; set; }
        public CommandResult Execute()
        {
            return new UserService().CreateContactInfo(PersonId,ContactInfoArg,UserLoginId);
        }
    }

    public class SetVisitorCommand:CommandBase,ICommand
    {
        public VisitorArg VisitorArg { get; set; }
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var result = new UserService(transaction.Context).SetVisitor(VisitorId,UserLoginId,UserAgentTypeId,SecurityToken,VisitorArg);
                transaction.CompleteTransaction();
                return result;
            }
        }
    }

    public class CreateJobPostCommand:CommandBase,ICommand
    {
        public JobPostCommandArg JobPostCommandArg { get; set; }
        public List<string> ModelIds { get; set; }

        public CreateJobPostCommand()
        {
            ModelIds = new List<string>();
        }

        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var result = new UserService(transaction.Context).CreateJobPost(JobPostCommandArg, ModelIds, UserLoginId);
                transaction.CompleteTransaction();
                return result;
            }
        }
    }

    public class CreateJobOfferCommand : CommandBase, ICommand
    {
        public string JobPostId { get; set; }
        public string ModelId { get; set; }
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var result = new UserService(transaction.Context).CreateJobOffer(JobPostId, ModelId, UserLoginId);
                transaction.CompleteTransaction();
                return result;
            }
        }
    }

    public class ActivateUserAccountCommand:CommandBase,ICommand
    {
        public string UserName { get; set; }
        public string VerificationCode { get; set; }
        public string NewPassword { get; set; }

        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var result = new UserService(transaction.Context).ActivateUserAccount(UserName,VerificationCode,NewPassword);
                transaction.CompleteTransaction();
                return result;
            }
        }
    }

    public class UserLoginCommand:CommandBase,ICommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public CommandResult Execute()
        {
            return new UserService().AuthenticateUser(UserName,Password);
        }
    }

    public class ResetPasswordCommand:CommandBase,ICommand
    {
        public string Email { get; set; }
        public CommandResult Execute()
        {
            return new UserService().ResetPassword(Email);
        }
    }


}
