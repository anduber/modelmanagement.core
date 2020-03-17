using System.Collections.Generic;
using System.Linq;
using ModelManagement.Core.Business.Business.Command.CommandArgs;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Data.Data.Model;
using ModelManagement.Core.Data.Data.Repository.GenericRepository;

namespace ModelManagement.Core.Business.Business.Command.AppService
{
    public class ContactService
    {
        private readonly ModelManagementContext _context;
        private readonly EntityRepository<ContactInformation> _contactInfoRepo;

        public ContactService(ModelManagementContext context = null)
        {
            _context = context ?? new ModelManagementContext();
            _contactInfoRepo = new EntityRepository<ContactInformation>(_context);
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
            _contactInfoRepo.AddRange(contactInfos);
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
            _contactInfoRepo.Add(contactInfo);
            return contactInfo;
        }

        public void RemoveContactInfo(string personId, string contactMechTypeId, string contactUrl)
        {
            var contactInfo = _contactInfoRepo.FirstOrDefault(t => t.PersonId == personId && t.ContactMechTypeId == contactMechTypeId && t.ContactUrl == contactUrl);
            if (contactInfo != null)
            {
                _contactInfoRepo.Delete(contactInfo);
            }
            else
            {
                Utility.CommandException("Contact Not Found!");
            }
        }
    }
}
