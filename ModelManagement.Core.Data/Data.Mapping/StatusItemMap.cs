using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class StatusItemMap : EntityTypeConfiguration<StatusItem>
    {
        public StatusItemMap()
        {
            
            HasKey(t => t.StatusId);
            HasOptional(t => t.StatusItem_StatusType)
                .WithMany(t => t.StatusType_StatusItems)
                .HasForeignKey(t => t.StatusTypeId);

            Property(t => t.StatusId).HasColumnName("STATUS_ID");
            Property(t => t.StatusTypeId).HasColumnName("STATUS_TYPE_ID");
            Property(t => t.Description).HasMaxLength(50).HasColumnName("DESCRIPTION");
            Property(t => t.SequenceId).HasMaxLength(5).HasColumnName("SEQUENCE_ID");
            Property(t => t.IsActive).HasMaxLength(1).HasColumnName("IS_ACTIVE");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
          

            ToTable("status_item");
        }
    }
}
