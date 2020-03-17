using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class Category : CommonEntity
    {
        public string PersonId { get; set; }
        public string CategoryTypeId { get; set; }
        public virtual CategoryType CategoryTypeId_CategoryType { get; set; }
        public virtual PersonalInformation PersonId_PersonalInformation { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }


    }
}
