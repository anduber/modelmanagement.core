using ModelManagement.Core.Business.Business.Command.Utils;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using System.Collections.Generic;
using ModelManagement.Core.Business.Business.Command.AppService;
using ModelManagement.Core.Business.Business.Command.CommandArgs;

namespace ModelManagement.Core.Business.Business.Command
{
    public class CreateContactInfosCommand : CommandBase, ICommand
    {
        public string PersonId { get; set; }
        public List<ContactInfoArg> ContactInfoArgs { get; set; }
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var contactService = new ContactService(transaction.Context);
                contactService.CreateContactInfos(ContactInfoArgs, PersonId, UserLoginId);
                transaction.CompleteTransaction();
                return Utility.CommandSuccess();
            }
        }
    }

    public class RemoveContactInfoCommand : CommandBase, ICommand
    {
        public string PersonId { get; set; }
        public string ContactMechTypeId { get; set; }
        public string ContactUrl { get; set; }
        public CommandResult Execute()
        {
            var contactService = new ContactService();
            contactService.RemoveContactInfo(PersonId, ContactMechTypeId, ContactUrl);
            return Utility.CommandSuccess();
        }
    }
}

