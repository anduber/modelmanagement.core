using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class OfferItemType:Entity
    {
        public OfferItemType()
        {
            OfferItemTypeId_OfferType = new List<OfferItemTypeMap>();
        }
        public string OfferItemTypeId { get; set; }
        public string Sequence { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }
        public virtual List<OfferItemTypeMap> OfferItemTypeId_OfferType { get; set; }

    }
}
