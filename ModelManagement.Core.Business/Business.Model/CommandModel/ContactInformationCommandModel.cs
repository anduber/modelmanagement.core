using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.CommandModel
{
    public class ContactInformationCommandModel
    {
        public string ContactInfoId { get; set; }
        public string ContactMechTypeId { get; set; }
        public string PersonId { get; set; }
        public string URL { get; set; }
        public string NewContactUrl { get; set; }
        public string UserLoginId { get; set; }

    }
}
