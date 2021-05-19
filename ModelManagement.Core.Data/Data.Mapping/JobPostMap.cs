using System.Data.Entity.ModelConfiguration;
using ModelManagement.Core.Data.Data.Model;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class JobPostMap:EntityTypeConfiguration<JobPost>
    {
        public JobPostMap()
        {
            HasKey(t => t.JobPostId);
            HasOptional(t => t.JobPost_UserId).WithMany(t => t.User_JobPosts).HasForeignKey(k => k.UserId);
            HasOptional(t => t.JobPost_AgentJobEnumId)
                .WithMany(t => t.Enumeration_AgentJobEnum)
                .HasForeignKey(k => k.AgentJobEnumId);
            HasOptional(t => t.JobPost_PaymentMethodEnumId).WithMany(t => t.Enumeration_JobPostPaymentMethodEnum).HasForeignKey(k => k.PaymentMethodEnumId);
            HasOptional(t => t.JobPost_AgentLocationGeoId).WithMany(t => t.Geo_JobPostAgentLocations).HasForeignKey(k => k.AgentLocationGeoId);
            HasOptional(t => t.JobPost_JobLocationGeoId).WithMany(t => t.Geo_JobPostJobLocationGeoes).HasForeignKey(k => k.JobLocationGeoId);
            HasOptional(t => t.JobPost_UserLoginId).WithMany(t => t.UserLogin_JobPostUserLogin).HasForeignKey(k => k.UserLoginId);
            HasOptional(t => t.JobPost_StatusId).WithMany(t => t.StatusItem_JobPostes).HasForeignKey(t => t.StatusId);
            HasOptional(t => t.JobPost_DurationOfContractEnumId).WithMany(t => t.Enumeration_DurationOfContract).HasForeignKey(t => t.DurationOfContract);

            Property(t => t.JobPostId).HasMaxLength(50).HasColumnName("JOB_POST_ID");
            Property(t => t.UserId).HasMaxLength(50).HasColumnName("USER_ID");
            Property(t => t.JobTitle).HasMaxLength(250).HasColumnName("JOB_TITLE");
            Property(t => t.JobDescription).HasColumnName("JOB_DESCRIPTION");
            Property(t => t.JobStartDate).HasColumnName("JOB_START_DATE");
            Property(t => t.JobDueDate).HasColumnName("JOB_DUE_DATE");
            Property(t => t.JobLocation).HasMaxLength(255).HasColumnName("JOB_LOCATION");
            Property(t => t.PaymentMethodEnumId).HasMaxLength(50).HasColumnName("PAYMENT_METHOD_ENUM_ID");
            Property(t => t.PaymentAmount).HasColumnName("PAYMENT_AMOUNT");
            Property(t => t.HeightFrom).HasColumnName("HEIGHT_FROM");
            Property(t => t.HeightThru).HasColumnName("HEIGHT_THRU");
            Property(t => t.WeightFrom).HasColumnName("WEIGHT_FROM");
            Property(t => t.WeightThru).HasColumnName("WEIGHT_THRU");
            Property(t => t.AgeFrom).HasColumnName("AGE_FROM");
            Property(t => t.AgeThru).HasColumnName("AGE_THRU");
            Property(t => t.DurationOfContract).HasMaxLength(50).HasColumnName("DURATION_OF_CONTRACT");
            Property(t => t.Complexion).HasMaxLength(50).HasColumnName("COMPLEXION");
            Property(t => t.HairColor).HasMaxLength(50).HasColumnName("HAIR_COLOR");
            Property(t => t.EyeColor).HasMaxLength(50).HasColumnName("EYE_COLOR");
            Property(t => t.Bust).HasColumnName("BUST");
            Property(t => t.Waist).HasColumnName("WAIST");
            Property(t => t.StatusId).HasMaxLength(50).HasColumnName("STATUS_ID");
            Property(t => t.Hip).HasColumnName("HIP");
            Property(t => t.DressSize).HasMaxLength(50).HasColumnName("DRESS_SIZE");
            Property(t => t.ShoeSize).HasColumnName("SHOE_SIZE");
            Property(t => t.JobLocationGeoId).HasMaxLength(50).HasColumnName("JOB_LOCATION_GEO_ID");
            Property(t => t.AgentJobEnumId).HasMaxLength(50).HasColumnName("AGENT_JOB_ENUM_ID");
            Property(t => t.AgentLocationGeoId).HasMaxLength(50).HasColumnName("AGENT_LOCATION_GEO_ID");
            Property(t => t.Quantity).HasColumnName("QUANTITY");
            Property(t => t.Sex).HasMaxLength(1).HasColumnName("SEX");
            Property(t => t.IsActive).HasMaxLength(1).HasColumnName("IS_ACTIVE");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            ToTable("job_post");
        }
    }
}
