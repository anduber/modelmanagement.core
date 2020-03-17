using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class UserAppl : CommonEntity
    {
        public UserAppl()
        {

        }
        public string UserId { get; set; }
        public string OfferTypeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ThruDate { get; set; }
        public string Comment { get; set; }
        public virtual User UserId_UserAppl { get; set; }
        public virtual OfferType OfferTypeId_OfferType { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }

    }

}
