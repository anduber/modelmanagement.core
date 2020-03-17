using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class UserRole:CommonEntity
    {
        public string UserId { get; set; }
        public string RoleTypeId { get; set; }
        public virtual User  UserId_UserRole{ get; set; }
        public virtual RoleType RoleTypeId_UserRole { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }

    }
}
