using System;

namespace ModelManagement.Core.Business.Business.Command.CommandArgs
{
    public class UserCommandArg
    {
        public string RoleTypeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string StatusId { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string Description { get; set; } 
    }

    public class JobPostCommandArg
    {
        public string UserId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime? JobDueDate { get; set; }
        public string PaymentMethodEnumId { get; set; }
        public string JobLocationGeoId { get; set; }
        public string AgentJobEnumId { get; set; }
        public string AgentLocationGeoId { get; set; }
    }

    public class AdminUserEmail
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginCommandResult
    {
        public bool IsLoginSuccess { get; set; }
        public string RequirePasswordChange { get; set; }
        public string IsUserActivated { get; set; }
        public string SecurityToken { get; set; }
        public string UserId { get; set; }
        public string UserLoginId { get; set; }

        public UserLoginCommandResult()
        {
            
        }

        public UserLoginCommandResult(bool isLoginSuccess,string requirePasswordChange,string isUserActivated,string securityToken=null)
        {
            IsLoginSuccess = isLoginSuccess;
            RequirePasswordChange = requirePasswordChange;
            IsUserActivated = isUserActivated;
            SecurityToken = securityToken;
        }
    }
}
