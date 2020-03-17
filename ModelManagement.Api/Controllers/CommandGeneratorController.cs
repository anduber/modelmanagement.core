using ModelManagement.Core.Business.Business.Command;
using ModelManagement.Core.Business.Business.Command.Utils;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using ModelManagement.Core.Business.Business.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ModelManagement.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CommandGeneratorController : ApiController
    {
        private readonly ModelManagementCommandServices modelManagementCommandServices;
        public CommandGeneratorController()
        {
            modelManagementCommandServices = new ModelManagementCommandServices();
        }

        #region UserCommands

        [HttpPost, Route("USRCMD_UpdateUserCommand")]
        public CommandResult UpdateUserCommand(UpdateUserCommand updateUserCommand)
        {
            return InvokeCommand(updateUserCommand);
        }
        [HttpPost, Route("USRCMD_RemoveUserCommand")]
        public CommandResult RemoveUserCommand(RemoveUserCommand removeUserCommand)
        {
            return InvokeCommand(removeUserCommand);
        }
        [HttpPost, Route("ChangeUserStatusCommand")]
        public CommandResult ChangeUserStatusCommand(ChangeUserStatusCommand changeUserStatusCommand)
        {
            return InvokeCommand(changeUserStatusCommand);
        }
        [HttpPost, Route("USRCMD_CreatePersonalInformationCommand")]
        public CommandResult CreatePersonalInformationCommand(CreatePersonalInformationCommand createPersonalInfoCommand)
        {
            return InvokeCommand(createPersonalInfoCommand);
        }
        [HttpPost, Route("UpdatePersonalInformationCommand")]
        public CommandResult UpdatePersonalInformationCommand(UpdatePersonalInformationCommand updatePersonalInformationCommand)
        {
            return InvokeCommand(updatePersonalInformationCommand);
        }
        [HttpPost, Route("USRCMD_CreateUpdatePhysicalInformationCommand")]
        public CommandResult CreateUpdatePhysicalInformationCommand(CreateUpdatePhysicalInformationCommand createUpdatePhysicalInformationCommand)
        {
            return InvokeCommand(createUpdatePhysicalInformationCommand);
        }
        [HttpPost, Route("USRCMD_ChangeUserPasswordCommand")]
        public CommandResult ChangeUserPasswordCommand(ChangeUserPasswordCommand changeUserPasswordCommand)
        {
            return InvokeCommand(changeUserPasswordCommand);
        }
        [HttpPost, Route("USRCMD_AuthenticateUserCommand")]
        public CommandResult AuthenticateUserCommand(AuthenticateUserCommand authenticateUserCommand)
        {
            return InvokeCommand(authenticateUserCommand);
        }
        [HttpPost, Route("RegisterModelCommand")]
        public CommandResult AuthenticateUserCommand(RegisterModelCommand registerModelCommand)
        {
            return InvokeCommand(registerModelCommand);
        }
        #endregion

        #region FileUploadCommands
        [HttpPost, Route("CreateUploadableCommand")]
        public CommandResult CreateUploadableCommand(CreateUploadableCommand createUploadableCommand)
        {
            return InvokeCommand(createUploadableCommand);
        }

        [HttpPost, Route("SaveUplodablesCommand")]
        public CommandResult SaveUplodablesCommand(SaveUplodablesCommand saveUplodablesCommand)
        {
            return InvokeCommand(saveUplodablesCommand);
        }
        [HttpPost, Route("RemoveUplodableCommand")]
        public CommandResult RemoveUplodableCommand(RemoveUplodableCommand removeUplodableCommand)
        {
            return InvokeCommand(removeUplodableCommand);
        }
        #endregion



        internal CommandResult InvokeCommand(ICommand command)
        {
            return modelManagementCommandServices.InvokeCommand(command);
        }
    }
}
