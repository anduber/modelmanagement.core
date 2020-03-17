using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class ContactMechType : CommonEntity
    {
        public ContactMechType()
        {
            ContactInformations = new List<ContactInformation>();
        }

        public string ContactMechTypeId { get; set; }
        public string Description { get; set; }
        public virtual List<ContactInformation> ContactInformations { get; set; }
    }
}
