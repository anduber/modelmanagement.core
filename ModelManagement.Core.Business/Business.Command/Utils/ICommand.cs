using ModelManagement.Core.Business.Business.Model.CommandModel;

namespace ModelManagement.Core.Business.Business.Command.Utils
{
    public interface ICommand
    {
        CommandResult Execute();
    }
}
