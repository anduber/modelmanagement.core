using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using ModelManagement.Core.Data.Data.Model;
using ModelManagement.Core.Data.Data.Repository;
using ModelManagement.Core.Data.Data.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Business.Business.Command.Utils;
using System.Drawing;
using System.IO;
using ModelManagement.Core.Business.Business.Command.AppService;
using ModelManagement.Core.Business.Business.Command.CommandArgs;

namespace ModelManagement.Core.Business.Business.Command
{
    public class FileUploadCommands
    {
    }

    public class CreateUploadableCommand : CommandBase, ICommand
    {
        public string PersonId { get; set; }
        public UplodableArg UplodableArg { get; set; }
        public CommandResult Execute()
        {
            var _fileUploadService = new FileUploadService();
            var uplodable = _fileUploadService.CreateUplodable(UplodableArg, PersonId, UserLoginId);
            return Utility.CommandSuccess(uplodable.FileUploadId);
        }
    }

    public class SaveUplodablesCommand : CommandBase, ICommand
    {
        public string PersonId { get; set; }
        public List<UplodableArg> UplodableArgs { get; set; }
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var fileUploadService = new FileUploadService(transaction.Context);
                foreach (var uplodableArg in UplodableArgs)
                {
                    fileUploadService.SaveUplodable(uplodableArg, PersonId, UserLoginId);
                }
                transaction.CompleteTransaction();
                return Utility.CommandSuccess();
            }
        }
    }

    public class RemoveUplodableCommand : CommandBase, ICommand
    {
        public string FileUploadId { get; set; }
        public CommandResult Execute()
        {
            new FileUploadService().RemoveUplodable(FileUploadId);
            return Utility.CommandSuccess();
        }
    }

}
