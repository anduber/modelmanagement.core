using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class StatusItemMap : EntityTypeConfiguration<StatusItem>
    {
        public StatusItemMap()
        {
            #region Configuration
            this.HasKey(t => t.StatusId);
            #endregion

            #region Property
            this.Property(t => t.StatusId).HasColumnName("STATUS_ID");
            this.Property(t => t.Description).HasMaxLength(50).HasColumnName("DESCRIPTION");
            this.Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("status_item");
        }
    }
}
