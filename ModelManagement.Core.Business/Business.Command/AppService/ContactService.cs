using System.Collections.Generic;
using System.Linq;
using ModelManagement.Core.Business.Business.Command.CommandArgs;
using ModelManagement.Core.Business.Business.Command.EntityRepositories;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Data.Data.Model;
using ModelManagement.Core.Data.Data.Repository.GenericRepository;

namespace ModelManagement.Core.Business.Business.Command.AppService
{
    public class ContactService:AppRepository
    {
        private AppRepository _appRepository;

        public ContactService(ModelManagementContext context = null) : base(context)
        {
            var appContext = context ?? new ModelManagementContext();
            _appRepository = new AppRepository(appContext);
        }

        public List<ContactInformation> CreateContactInfos(List<ContactInfoArg> contactArgs, string personId, string userLoginId)
        {
            var contactInfos = (from contact in contactArgs
                                where !string.IsNullOrEmpty(contact.ContactUrl)
                                select new ContactInformation()
                                {
                                    PersonId = personId,
                                    ContactMechTypeId = contact.ContactMechTypeId,
                                    ContactUrl = contact.ContactUrl,
                                    UserLoginId = userLoginId
                                }).ToList();
            ContactInfo().AddRange(contactInfos);
            return contactInfos;
        }

        public ContactInformation CrateContactInfo(ContactInfoArg contactInfoArg, string personId, string userLoginId)
        {
            var contactInfo = new ContactInformation
            {
                ContactMechTypeId = contactInfoArg.ContactMechTypeId,
                ContactUrl = contactInfoArg.ContactUrl,
                PersonId = personId,
                UserLoginId = userLoginId
            };
            ContactInfo().Add(contactInfo);
            return contactInfo;
        }

        public void RemoveContactInfo(string personId, string contactMechTypeId, string contactUrl)
        {
            var contactInfo = ContactInfo().FirstOrDefault(t => t.PersonId == personId && t.ContactMechTypeId == contactMechTypeId && t.ContactUrl == contactUrl);
            if (contactInfo != null)
            {
                ContactInfo().Delete(contactInfo);
            }
            else
            {
                Utility.CommandException("Contact Not Found!");
            }
        }

        public CommandResult UpdateContactInfos(string personId,List<ContactInfoArg> contactInfoArgs,string userLoginId)
        {
            List<ContactInformation> result;
            var contacts = ContactInfo().Filter(t => t.PersonId == personId);
            if (contacts.Any())
            {
                foreach (var contactInformation in contacts)
                {
                    ContactInfo().Remove(contactInformation);
                }
                result = SetContactInfoArgs(personId, contactInfoArgs, userLoginId);
            }
            else
            {
                result = SetContactInfoArgs(personId, contactInfoArgs, userLoginId);
            }
            ContactInfo().AddRange(result);
            return new CommandResult();
        }

        public List<ContactInformation> SetContactInfoArgs(string personId,List<ContactInfoArg> contactInfoArgs,string userLoginId)
        {
            return contactInfoArgs.Select(contactInformation => new ContactInformation
            {
                PersonId = personId,
                ContactMechTypeId = contactInformation.ContactMechTypeId,
                ContactUrl = contactInformation.ContactUrl,
                UserLoginId = userLoginId
            }).ToList();
        }
    }
}
