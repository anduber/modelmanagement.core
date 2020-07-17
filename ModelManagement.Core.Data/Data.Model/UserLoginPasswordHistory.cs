using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class UserLoginPasswordHistory:Entity
    {
        public DateTime FromDate { get; set; }
        public DateTime? ThruDate { get; set; }
        public string CurrentPassword { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }
    }
}
