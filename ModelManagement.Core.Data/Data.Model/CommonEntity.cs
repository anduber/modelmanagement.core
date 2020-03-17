using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class CommonEntity
    {
        public CommonEntity()
        {
            CreatedStamp = DateTime.Now;
            LastUpdatedStamp = DateTime.Now;
        }
        public string UserLoginId { get; set; }
        public DateTime? CreatedStamp { get; set; }
        public DateTime? LastUpdatedStamp { get; set; }
    }
}
