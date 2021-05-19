using System.Data.Entity.ModelConfiguration;
using ModelManagement.Core.Data.Data.Model;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class JobPostDetailMap:EntityTypeConfiguration<JobPostDetail>
    {
        public JobPostDetailMap()
        {
            HasKey(t => new {t.JobPostId,t.JobPostSeqId} );
            HasRequired(t => t.JobPostDeail_JobPost)
                .WithMany(t => t.JobPost_JobPostDetails)
                .HasForeignKey(t => t.JobPostId);
            Property(t => t.JobPostId).HasMaxLength(50).HasColumnName("JOB_POST_ID");
            Property(t => t.JobPostSeqId).HasMaxLength(50).HasColumnName("JOB_POST_SEQ_ID");
            Property(t => t.ApplicationsOnMedia).HasMaxLength(50).HasColumnName("APPLICATIONS_ON_MEDIA");

            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            ToTable("job_post_detail");
        }
    }
}