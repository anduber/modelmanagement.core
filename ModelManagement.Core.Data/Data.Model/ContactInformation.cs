using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class ContactInformation : CommonEntity
    {
        //public string ContactInfoId { get; set; }
        public string PersonId { get; set; }
        public string ContactMechTypeId { get; set; }
        public string ContactUrl { get; set; }
        public virtual ContactMechType ContactMechTypeId_ContactMechType { get; set; }
        public virtual PersonalInformation PersonId_PersonalInformation { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }

    }
}
