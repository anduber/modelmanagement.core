using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class Adderss : CommonEntity
    {
        public string PersonId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public virtual PersonalInformation PersonId_PersonalInformation { get; set; }
    }
}
