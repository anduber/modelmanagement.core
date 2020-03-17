using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class OfferItemTypeMap:CommonEntity
    {
        public string OfferTypeId { get; set; }
        public string OfferItemTypeId { get; set; }
        public virtual OfferType OfferTypeId_OfferType { get; set; }
        public virtual OfferItemType OfferItemTypeId_OfferItemType { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }

    }
}
