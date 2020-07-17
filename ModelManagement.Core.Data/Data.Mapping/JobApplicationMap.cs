using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class JobApplicationMap : EntityTypeConfiguration<JobApplication>
    {
        public JobApplicationMap()
        {
            HasKey(t => t.JobApplicationId);

            HasOptional(t => t.JobApplication_JobPost)
                .WithMany(t => t.JobPost_JobApplications)
                .HasForeignKey(t => t.JobPostId);
            HasOptional(t => t.JobApplication_ApplyingUser)
                .WithMany(t => t.User_JobApplications)
                .HasForeignKey(t => t.ApplyingUserId);
            HasOptional(t => t.JobApplication_StatusItem)
                .WithMany(t => t.StatusItem_JobApplications)
                .HasForeignKey(t => t.StatusId);


            Property(t => t.JobApplicationId).HasMaxLength(50).HasColumnName("JOB_APPLICATION_ID");
            Property(t => t.JobPostId).HasMaxLength(50).HasColumnName("JOB_POST_ID");
            Property(t => t.ApplyingUserId).HasMaxLength(50).HasColumnName("APPLYING_USER_ID");
            Property(t => t.StatusId).HasMaxLength(50).HasColumnName("STATUS_ID");
            Property(t => t.ApplicationDate).HasColumnName("APPLICATION_DATE");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            ToTable("job_application");
        }
    }
}
