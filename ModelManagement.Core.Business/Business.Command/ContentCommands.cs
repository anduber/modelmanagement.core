using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using System.Collections.Generic;
using ModelManagement.Core.Business.Business.Command.Utils;
using ModelManagement.Core.Business.Business.Command.AppService;
using ModelManagement.Core.Business.Business.Command.CommandArgs;

namespace ModelManagement.Core.Business.Business.Command
{
    public class ContentCommands
    {
    }

    public class CreateUploadableCommand : CommandBase, ICommand
    {
        public string PersonId { get; set; }
        public UploadableArg UplodableArg { get; set; }
        public CommandResult Execute()
        {
            var fileUploadService = new ContentService();
            var uplodable = fileUploadService.CreateUplodable(UplodableArg, PersonId, UserLoginId);
            return Utility.CommandSuccess(uplodable.FileUploadId);
        }
    }

    public class SaveUplodablesCommand : CommandBase, ICommand
    {
        public string PersonId { get; set; }
        public List<UploadableArg> UplodableArgs { get; set; }
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var fileUploadService = new ContentService(transaction.Context);
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
            new ContentService().RemoveUplodable(FileUploadId);
            return Utility.CommandSuccess();
        }
    }

    public class CreateContentsCommand : CommandBase, ICommand
    {
        public string UserId { get; set; }
        public List<ContentArg> ContentArgs { get; set; }

        public CreateContentsCommand()
        {
            ContentArgs = new List<ContentArg>();
        }

        public CommandResult Execute()
        {
            using (var transaction  = new TransactionScope())
            {
                var contentService = new ContentService(transaction.Context);
                contentService.AddContents(ContentArgs, UserId, UserLoginId);
                transaction.CompleteTransaction();
                return Utility.CommandSuccess();
            }
        }
    }

    public class RemoveContentCommand : CommandBase, ICommand
    {
        public string ContentId { get; set; }
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var contentService = new ContentService(transaction.Context);
                contentService.RemoveContent(ContentId);
                transaction.CompleteTransaction();
                return Utility.CommandSuccess();
            }
        }
    }

    public class SetProfilePictureCommand : CommandBase, ICommand
    {
        public string UserId { get; set; }
        public string ContentId { get; set; }
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var contentService = new ContentService(transaction.Context);
                contentService.SetProfilePicture(UserId, ContentId);
                transaction.CompleteTransaction();
                return Utility.CommandSuccess();
            }
        }
    }




}
