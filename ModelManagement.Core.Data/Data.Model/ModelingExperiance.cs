using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class ModelingExperiance : CommonEntity
    {
        public string ModelingExperianceId { get; set; }
        public string PersonId { get; set; }
        public string ExperianceInfo { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }
    }
}
