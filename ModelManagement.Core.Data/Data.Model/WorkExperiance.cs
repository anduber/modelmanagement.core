using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class WorkExperiance : Entity
    {
        public string WorkExperianceId { get; set; }
        public string PersonId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ThruDate { get; set; }
        public string WorkExperianceInfo { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }
    }
}
