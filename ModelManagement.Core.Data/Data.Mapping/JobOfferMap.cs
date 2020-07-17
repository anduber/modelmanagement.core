using System.Data.Entity.ModelConfiguration;
using ModelManagement.Core.Data.Data.Model;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class JobOfferMap:EntityTypeConfiguration<JobOffer>
    {
        public JobOfferMap()
        {
            HasKey(t => t.JobOfferId);
            HasOptional(t => t.JobPost_JobOfferId).WithMany(t => t.JobPost_JobOffers).HasForeignKey(k => k.JobPostId);
            HasOptional(t => t.JobOffer_ModelUserId).WithMany(t => t.User_JobOffers).HasForeignKey(k => k.OfferedUserId);
            HasOptional(t => t.JobPost_StatusId).WithMany(t => t.StatusItem_JobOffers).HasForeignKey(k => k.StatusId);
            HasOptional(t => t.JobOffer_UserLoginId).WithMany(t => t.UserLogin_JobOfferUserLogin).HasForeignKey(k => k.UserLoginId);

            Property(t => t.JobOfferId).HasMaxLength(50).HasColumnName("JOB_OFFER_ID");
            Property(t => t.JobPostId).HasMaxLength(50).HasColumnName("JOB_POST_ID");
            Property(t => t.OfferedUserId).HasMaxLength(50).HasColumnName("OFFERED_USER_ID");
            Property(t => t.StatusId).HasMaxLength(50).HasColumnName("STATUS_ID");
            Property(t => t.IsSeen).HasMaxLength(1).HasColumnName("IS_SEEN");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            ToTable("job_offer");
        }
    }
}
