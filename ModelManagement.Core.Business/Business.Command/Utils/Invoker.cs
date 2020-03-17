using System;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;

namespace ModelManagement.Core.Business.Business.Command.Utils
{
    public class Invoker
    {
        public Invoker()
        {

        }

        public static CommandResult InvokeCommand(ICommand command)
        {
            return command.Execute();
        }

        public CommandResult Invoke(ICommand command)
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
    }
}
