using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class RoleType : Entity
    {
        public RoleType()
        {
            RoleTypeId_UserRoles = new List<UserRole>();
        }
        public string RoleTypeId { get; set; }
        public string Description { get; set; }
        public string InitialStatusId { get; set; }
        public virtual List<UserRole> RoleTypeId_UserRoles { get; set; }
        public virtual StatusItem RoleType_InitialStatusId { get; set; }
    }
}
