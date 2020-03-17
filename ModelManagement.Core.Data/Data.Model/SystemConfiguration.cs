using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class SystemConfiguration:CommonEntity
    {
        public string SystemConfigurationId { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string ConfigurationValue { get; set; }
    }
}
