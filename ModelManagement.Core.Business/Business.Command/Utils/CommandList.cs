
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Command.Utils
{
    public class CommandList
    {
        public static IEnumerable<ICommand> ListAvailableCommand()
        {
            var commandType = typeof(ICommand);
            var commands = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => commandType.IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<ICommand>().ToList();
            return commands;
        }

        public static ICommand GetCommand(string commandName)
        {
            return ListAvailableCommand().FirstOrDefault(t => t.GetType().Name == commandName);
        }
    }
}
