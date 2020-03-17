using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Command.Utils
{
    public class CommandParser
    {
        readonly IEnumerable<ICommand> availableCommands;

        public CommandParser(IEnumerable<ICommand> availableCommand)
        {
            this.availableCommands = availableCommand;
        }

        internal ICommand ParseCommand(ICommand command)
        {
            var _command = GetRequestedCommand(command.GetType().Name);
            if (_command != null)
            {
                return command;
            }
            else
            {
                return null;
            }

        }

        internal ICommand GetRequestedCommand(string commandName)
        {
            return availableCommands.FirstOrDefault(t => t.GetType().Name == commandName);
        }
    }
}
