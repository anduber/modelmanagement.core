using System;
using System.Collections.Generic;

namespace ModelManagement.Core.Data.Data.Model
{
    public class JobPost:Entity
    {
        public JobPost()
        {
            JobPost_JobApplications = new List<JobApplication>();
            JobPost_JobOffers = new List<JobOffer>();
            JobPost_JobPostDetails = new List<JobPostDetail>();
        }
        public string JobPostId { get; set; }
        public string UserId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string StatusId { get; set; }
        public DateTime? JobStartDate { get; set; }
        public DateTime? JobDueDate { get; set; }
        public string PaymentMethodEnumId { get; set; }
        public decimal? PaymentAmount { get; set; }
        public decimal? HeightFrom { get; set; }
        public decimal? HeightThru { get; set; }
        public decimal? WeightFrom { get; set; }
        public decimal? WeightThru { get; set; }
        public decimal? AgeFrom { get; set; }
        public decimal? AgeThru { get; set; }
        public string JobLocation { get; set; }
        public string JobLocationGeoId { get; set; }
        public string AgentJobEnumId { get; set; }
        public string AgentLocationGeoId { get; set; }
        public decimal? Quantity { get; set; }
        public string Sex { get; set; }
        public string Complexion { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public double? Bust { get; set; }
        public double? Waist { get; set; }
        public double? Hip { get; set; }
        public string DressSize { get; set; }
        public double? ShoeSize { get; set; }
        public string DurationOfContract { get; set; }
        public string IsActive { get; set; }
        public virtual User JobPost_UserId { get; set; }
        public virtual Enumeration JobPost_PaymentMethodEnumId { get; set; }
        public virtual Enumeration JobPost_AgentJobEnumId { get; set; }
        public virtual Geo JobPost_JobLocationGeoId { get; set; }
        public virtual Geo JobPost_AgentLocationGeoId { get; set; }
        public virtual UserLogin JobPost_UserLoginId { get; set; }
        public virtual List<JobOffer> JobPost_JobOffers { get; set; }
        public virtual List<JobApplication> JobPost_JobApplications { get; set; }
        public virtual StatusItem JobPost_StatusId { get; set; }
        public virtual List<JobPostDetail> JobPost_JobPostDetails { get; set; }
        public virtual Enumeration JobPost_DurationOfContractEnumId { get; set; }
        

        public void SetProperty(string userId,string jobTitle,string jobDescription,DateTime? jobDueDate,string paymentMethodEnumId,string jobLocationGeoId,string agentJobEnumId,string agentLocationGeoId,string jobLocation)
        {
            UserId = userId;
            JobTitle = jobTitle;
            JobDescription = jobDescription;
            JobDueDate = jobDueDate;
            PaymentMethodEnumId = paymentMethodEnumId;
            JobLocationGeoId = jobLocationGeoId;
            AgentJobEnumId = agentJobEnumId;
            AgentLocationGeoId = agentLocationGeoId;
            JobLocation = jobLocation;
        }
    }
}
