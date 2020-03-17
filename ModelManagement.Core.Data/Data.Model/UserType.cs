using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class UserType : CommonEntity
    {
        public UserType()
        {
            //UserApplId_UserAppls = new List<UserAppl>();
        }
        public string UserTypeId { get; set; }
        public string Sequence { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public int? ValidNoOfDays { get; set; }
        public double? FeeAmount { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }
        //public virtual List<UserAppl> UserApplId_UserAppls { get; set; }
    }
}
