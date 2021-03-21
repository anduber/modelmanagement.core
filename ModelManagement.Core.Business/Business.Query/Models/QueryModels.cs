using ModelManagement.Core.Business.Business.Model.Utils;
using System;

namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class JobPostListModel : QueryEntity
    {
        public string JobPostId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime? JobStartDate { get; set; }
        public DateTime? JobDueDate { get; set; }
        public string PaymentMethodEnumId { get; set; }
        public decimal? PaymentAmount { get; set; }
        public decimal? HeightFrom { get; set; }
        public decimal? HeightThru { get; set; }
        public decimal? AgeFrom { get; set; }
        public decimal? AgeThru { get; set; }
        public string JobLocation { get; set; }
        public string JobLocationGeoId { get; set; }
        public EntityDescription JobLocationGeo { get; set; }
        public string AgentJobEnumId { get; set; }
        public string AgentLocationGeoId { get; set; }
        public decimal? Quantity { get; set; }
        public string Sex { get; set; }
        public string IsActive { get; set; }
        public int NoOfPeopleApplied { get; set; }
    }

    public class JobOfferListModel : QueryEntity
    {
        public string JobOfferId { get; set; }
        public string JobPostId { get; set; }
        public EntityDescription JobPost { get; set; }
        public string ModelUserId { get; set; }
        public EntityDescription ModelUser { get; set; }
        public string StatusId { get; set; }
        public string IsSeen { get; set; }
    }

    public class JobApplicationListModel : QueryEntity
    {
        public string JobApplicationId { get; set; }
        public string JobPostId { get; set; }
        public string ApplyingUserId { get; set; }
        public string ApplyingPersonId { get; set; }
        public string ApplyingUser { get; set; }
        public string StatusId { get; set; }
        public byte[] ProfileImage { get; set; }
        public DateTime? ApplicationDate { get; set; }
    }

    public class SkillListModel:QueryEntity
    {
        public string PersonId { get; set; }
        public string SkillTypeId { get; set; }
        public string SkillLevelEnumId { get; set; }
        public string SkillInfo { get; set; }
    }
}
