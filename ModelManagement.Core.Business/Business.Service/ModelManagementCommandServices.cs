using ModelManagement.Core.Business.Business.Command;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using System;
using ModelManagement.Core.Business.Business.Command.Utils;

namespace ModelManagement.Core.Business.Business.Service
{
    public class ModelManagementCommandServices
    {
        
        

        public ModelManagementCommandServices()
        {

        }


        #region InvokeCommand
        public CommandResult InvokeCommand(ICommand command)
        {
            try
            {
                return command.Execute();
            }
            catch (Exception e)
            {
                return Utility.CommandError(e.Message);
            }

        }
        #endregion

    }
}
