using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class OfferType:CommonEntity
    {
        public OfferType()
        {
            OfferTypeId_OfferType = new List<OfferItemTypeMap>();
        }
        public string OfferTypeId { get; set; }
        public string Sequence { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public int? ValidNoOfDays { get; set; }
        public decimal? FeeAmount { get; set; }
        public string IsActive { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }
        public virtual List<OfferItemTypeMap> OfferTypeId_OfferType { get; set; }
        public virtual List<UserAppl> UserApplId_UserAppls { get; set; }
    }
}
