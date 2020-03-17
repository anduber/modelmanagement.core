using ModelManagement.Core.Business.Business.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class JobPostListModel:QueryEntity
    {
        public string JobPostId { get; set; }
        public string UserId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime? JobDueDate { get; set; }
        public string PaymentMethodEnumId { get; set; }
        public string JobLocationGeoId { get; set; }
        public string AgentJobEnumId { get; set; }
        public string AgentLocationGeoId { get; set; }
        public string IsActive { get; set; }
    }

    public class JobOfferListModel:QueryEntity
    {
        public string JobOfferId { get; set; }
        public string JobPostId { get; set; }
        public EntityDescription JobPost { get; set; }
        public string ModelUserId { get; set; }
        public EntityDescription ModelUser { get; set; }
        public string StatusId { get; set; }
        public string IsSeen { get; set; }
    }
}
