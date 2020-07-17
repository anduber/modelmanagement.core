using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class UserStatus:Entity
    {

        public string UserStatusId { get; set; }
        public string UserId { get; set; }
        public string StatusId { get; set; }
        public virtual User UserStatus_UserId { get; set; }
        public virtual StatusItem StatusId_UserStatsuTypes{ get; set; }
        public virtual UserLogin UserLoginId_UserStatus { get; set; }
    }
}
