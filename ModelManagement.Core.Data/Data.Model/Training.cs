using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class Training : CommonEntity
    {
        public string TrainingId { get; set; }
        public string PersonId { get; set; }
        public string TrainingInfo { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }
    }
}
