using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.CommandModel
{
    public class UserCommandModel
    {
        public string PersonId { get; set; }
        public string RoleTypeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string StatusId { get; set; }
    }

    public class ChangeUserPasswordCommandModel
    {
        public string PersonId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
