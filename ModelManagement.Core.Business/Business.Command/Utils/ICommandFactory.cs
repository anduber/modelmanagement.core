using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Command.Utils
{
    public interface ICommandFactory
    {
        string CommandName { get; }
        ICommand MakeCommand(ICommand command);
    }
}
