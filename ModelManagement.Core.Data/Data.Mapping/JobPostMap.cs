using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelManagement.Core.Data.Data.Model;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class JobPostMap:EntityTypeConfiguration<JobPost>
    {
        public JobPostMap()
        {
            HasKey(t => t.JobPostId);
            HasOptional(t => t.JobPost_UserId).WithMany(t => t.User_JobPosts).HasForeignKey(k => k.UserId);
            HasOptional(t => t.JobPost_AgentJobEnumId).WithMany(t => t.Enumeration_AgentJobEnum).HasForeignKey(k => k.AgentJobEnumId);
            HasOptional(t => t.JobPost_PaymentMethodEnumId).WithMany(t => t.Enumeration_JobPostPaymentMethodEnum).HasForeignKey(k => k.PaymentMethodEnumId);
            HasOptional(t => t.JobPost_AgentLocationGeoId).WithMany(t => t.Geo_JobPostAgentLocations).HasForeignKey(k => k.AgentLocationGeoId);
            HasOptional(t => t.JobPost_JobLocationGeoId).WithMany(t => t.Geo_JobPostJobLocationGeoes).HasForeignKey(k => k.JobLocationGeoId);
            HasOptional(t => t.JobPost_UserLoginId).WithMany(t => t.UserLogin_JobPostUserLogin).HasForeignKey(k => k.UserLoginId);


            Property(t => t.JobPostId).HasMaxLength(50).HasColumnName("JOB_POST_ID");
            Property(t => t.UserId).HasMaxLength(50).HasColumnName("USER_ID");
            Property(t => t.JobTitle).HasMaxLength(250).HasColumnName("JOB_TITLE");
            Property(t => t.JobDescription).HasColumnName("JOB_DESCRIPTION");
            Property(t => t.JobDueDate).HasColumnName("JOB_DUEDATE");
            Property(t => t.PaymentMethodEnumId).HasMaxLength(50).HasColumnName("PAYMENT_METHOD_ENUM_ID");
            Property(t => t.JobLocationGeoId).HasMaxLength(50).HasColumnName("JOB_LOCATION_GEO_ID");
            Property(t => t.AgentJobEnumId).HasMaxLength(50).HasColumnName("AGENT_JOB_ENUM_ID");
            Property(t => t.AgentLocationGeoId).HasMaxLength(50).HasColumnName("AGENT_LOCATION_GEO_ID");
            Property(t => t.IsActive).HasMaxLength(1).HasColumnName("IS_ACTIVE");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            ToTable("job_post");
        }
    }
}
