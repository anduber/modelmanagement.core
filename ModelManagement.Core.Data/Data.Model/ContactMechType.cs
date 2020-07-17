using System.Collections.Generic;

namespace ModelManagement.Core.Data.Data.Model
{
    public class ContactMechType : Entity
    {
        public ContactMechType()
        {
            ContactInformations = new List<ContactInformation>();
        }

        public string ContactMechTypeId { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public virtual List<ContactInformation> ContactInformations { get; set; }
    }
}
